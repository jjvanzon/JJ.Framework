using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.Collections;
using FluentNHibernate.Utils;

namespace FluentNHibernate.Visitors
{
    public delegate void PairBiDirectionalManyToManySidesDelegate(MappingModel.Collections.CollectionMapping current, IEnumerable<MappingModel.Collections.CollectionMapping> possibles, bool wasResolved);

    public class RelationshipPairingVisitor : DefaultMappingModelVisitor
    {
        readonly PairBiDirectionalManyToManySidesDelegate userControlledPair;
        readonly List<MappingModel.Collections.CollectionMapping> manyToManys = new List<MappingModel.Collections.CollectionMapping>();
        readonly List<MappingModel.Collections.CollectionMapping> oneToManys = new List<MappingModel.Collections.CollectionMapping>();
        readonly List<ManyToOneMapping> references = new List<ManyToOneMapping>();

        public RelationshipPairingVisitor(PairBiDirectionalManyToManySidesDelegate userControlledPair)
        {
            this.userControlledPair = userControlledPair;
        }

        public override void Visit(IEnumerable<HibernateMapping> mappings)
        {
            base.Visit(mappings);

            PairManyToManys(manyToManys);
            PairOneToManys(oneToManys, references);
        }

        public override void ProcessCollection(CollectionMapping mapping)
        {
            if (mapping.Relationship is ManyToManyMapping)
                manyToManys.Add(mapping);
            if (mapping.Relationship is OneToManyMapping)
                oneToManys.Add(mapping);
        }

        public override void ProcessManyToOne(ManyToOneMapping manyToOneMapping)
        {
            references.Add(manyToOneMapping);
        }

        static void PairOneToManys(IEnumerable<MappingModel.Collections.CollectionMapping> collections, IEnumerable<ManyToOneMapping> refs)
        {
            var orderedCollections = collections.OrderBy(x => x.Name).ToArray();
            var orderedRefs = refs.OrderBy(x => x.Name).ToArray();

            foreach (var collection in orderedCollections)
            {
                var type = collection.ContainingEntityType;
                var reference = orderedRefs.FirstOrDefault(x => x.OtherSide == null && x.Class.GetUnderlyingSystemType() == type);

                if (reference == null) continue;

                collection.OtherSide = reference;
                reference.OtherSide = collection;
            }
        }

        void PairManyToManys(IEnumerable<MappingModel.Collections.CollectionMapping> rs)
        {
            if (!rs.Any()) return;

            var current = rs.First();
            var wasResolved = true;

            // get any candidates for the other side of the relationship
            var candidates = rs
                .Where(x => both_collections_point_to_each_others_types(x, current));

            // try to pair the current side with the potential other sides
            var mapping = current;

            if (candidates.Count() == 1)
                mapping = PairExactMatches(rs, current, candidates);
            else if (candidates.Count() > 1)
                mapping = PairFuzzyMatches(rs, current, candidates);

            if (mapping == null)
            {
                // couldn't pair at all, going to defer to the user for this one
                // and if they can't do anything we'll just treat it as uni-directional
                mapping = current;
                wasResolved = false;
            }

            userControlledPair(mapping, rs, wasResolved);

            // both collections have been paired, so remove them
            // from the available collections
            PairManyToManys(rs.Except(mapping, (MappingModel.Collections.CollectionMapping)mapping.OtherSide));
        }

        static string GetMemberName(Member member)
        {
            if (member is MethodMember && member.Name.StartsWith("Get"))
                return member.Name.Substring(3);

            return member.Name;
        }

        static LikenessContainer GetLikeness(MappingModel.Collections.CollectionMapping currentMapping, MappingModel.Collections.CollectionMapping mapping)
        {
            var currentMemberName = GetMemberName(currentMapping.Member);
            var mappingMemberName = GetMemberName(mapping.Member);

            return new LikenessContainer
            {
                Collection = currentMapping,
                CurrentMemberName = currentMemberName,
                MappingMemberName = mappingMemberName,
                Differences = StringLikeness.EditDistance(currentMemberName, mappingMemberName)
            };
        }

        static bool both_collections_point_to_each_others_types(MappingModel.Collections.CollectionMapping left, MappingModel.Collections.CollectionMapping right)
        {
            return left.ContainingEntityType == right.ChildType &&
                left.ChildType == right.ContainingEntityType;
        }

        static bool likeness_within_threshold(LikenessContainer current)
        {
            return current.Differences != current.CurrentMemberName.Length;
        }

        static MappingModel.Collections.CollectionMapping PairFuzzyMatches(IEnumerable<MappingModel.Collections.CollectionMapping> rs, MappingModel.Collections.CollectionMapping current, IEnumerable<MappingModel.Collections.CollectionMapping> potentialOtherSides)
        {
            // no exact matches found, drop down to a levenshtein distance
            var mapping = current;

            var likenesses = potentialOtherSides
                .Select(x => GetLikeness(x, current))
                .Where(likeness_within_threshold)
                .OrderBy(x => x.Differences);

            var first = likenesses.FirstOrDefault();

            if (first == null || AnyHaveSameLikeness(likenesses, first))
            {
                // couldn't find a definitive match, return nothing and we'll handle
                // this further up
                return null;
            }

            var otherSide = likenesses.First().Collection;

            // got the other side of the relationship
            // lets make sure that the side that we're on now (mapping!)
            // is actually the relationship we want
            mapping = FindAlternative(rs, mapping, otherSide) ?? mapping;

            mapping.OtherSide = otherSide;
            otherSide.OtherSide = mapping;

            return mapping;
        }

        static MappingModel.Collections.CollectionMapping PairExactMatches(IEnumerable<MappingModel.Collections.CollectionMapping> rs, MappingModel.Collections.CollectionMapping current, IEnumerable<MappingModel.Collections.CollectionMapping> potentialOtherSides)
        {
            var otherSide = potentialOtherSides.Single();
                
            // got the other side of the relationship
            // lets make sure that the side that we're on now (mapping!)
            // is actually the relationship we want
            var mapping = FindAlternative(rs, current, otherSide) ?? current;

            mapping.OtherSide = otherSide;
            otherSide.OtherSide = mapping;

            return mapping;
        }

        static MappingModel.Collections.CollectionMapping FindAlternative(IEnumerable<MappingModel.Collections.CollectionMapping> rs, MappingModel.Collections.CollectionMapping current, MappingModel.Collections.CollectionMapping otherSide)
        {
            var alternative = rs
                .Where(x => x.ContainingEntityType == current.ContainingEntityType)
                .Select(x => GetLikeness(x, otherSide))
                .OrderBy(x => x.Differences)
                .FirstOrDefault();

            if (alternative == null)
                return null;

            return alternative.Collection;
        }

        static bool AnyHaveSameLikeness(IEnumerable<LikenessContainer> likenesses, LikenessContainer current)
        {
            return likenesses
                .Except(current)
                .Any(x => x.Differences == current.Differences);
        }

        class LikenessContainer
        {
            public MappingModel.Collections.CollectionMapping Collection { get; set; }
            public string CurrentMemberName { get; set; }
            public string MappingMemberName { get; set; }
            public int Differences { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is LikenessContainer)
                {
                    return ((LikenessContainer)obj).CurrentMemberName == CurrentMemberName &&
                        ((LikenessContainer)obj).MappingMemberName == MappingMemberName;
                }

                return false;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int result = (CurrentMemberName != null ? CurrentMemberName.GetHashCode() : 0);
                    result = (result * 397) ^ (MappingMemberName != null ? MappingMemberName.GetHashCode() : 0);
                    return result;
                }
            }
        }
    }
}