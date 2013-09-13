using System;
using System.Xml;

namespace Puzzle.NCore.Runtime.Serialization
{
    public class ArrayObject : ObjectBase
    {
        //public IList Items = new ArrayList();
        public Array Items;


        public override string ToString()
        {
            return string.Format("Count = {0} : {1}", Items.Length, Type.Name);
        }

        public override void Serialize(XmlTextWriter xml)
        {
            xml.WriteStartElement("array");
            xml.WriteAttributeString("id", ID.ToString());
            xml.WriteAttributeString("type", Type.FullName);

            //int[] dimensions = new int[items.Rank];

            //foreach (ObjectBase element in Items)
            //{
            //    xml.WriteStartElement("element");
            //    element.SerializeReference(xml);
            //    xml.WriteEndElement();
            //}

            Array arr = Items;
            int rank;
            int[] dimensions;
            int[] lowerBounds;
            int[] upperBounds;
            SetupLoopData(arr, out rank, out dimensions, out lowerBounds, out upperBounds);

            do
            {
                ObjectBase element = (ObjectBase) arr.GetValue(dimensions);

                xml.WriteStartElement("element");
                xml.WriteAttributeString("index", dimensions.ToString());
                element.SerializeReference(xml);
                xml.WriteEndElement();
            } while (IncreaseDimension(dimensions, lowerBounds, upperBounds, rank - 1));

            xml.WriteEndElement();
        }

        private static void SetupLoopData(Array arr, out int rank, out int[] dimensions, out int[] lowerBounds,
                                          out int[] upperBounds)
        {
            rank = arr.Rank;
            dimensions = new int[rank];
            lowerBounds = new int[rank];
            upperBounds = new int[rank];

            for (int dimension = 0; dimension < rank; dimension++)
            {
                lowerBounds[dimension] = arr.GetLowerBound(dimension);
                upperBounds[dimension] = arr.GetUpperBound(dimension);

                //setup start values
                dimensions[dimension] = lowerBounds[dimension];
            }
        }

        private static bool IncreaseDimension(int[] dimensions, int[] lowerBounds, int[] upperBounds, int dimension)
        {
            dimensions[dimension]++;
            if (dimensions[dimension] > upperBounds[dimension])
            {
                dimensions[dimension] = lowerBounds[dimension];
                if (dimension > 0)
                    return IncreaseDimension(dimensions, lowerBounds, upperBounds, dimension - 1);
                else
                    return false;
            }

            return true;
        }

        public override void SerializeReference(XmlTextWriter xml)
        {
            xml.WriteAttributeString("id-ref", ID.ToString());
        }


        public override object GetValue()
        {
            Array arr = Items;
            int rank;
            int[] dimensions;
            int[] lowerBounds;
            int[] upperBounds;
            SetupLoopData(arr, out rank, out dimensions, out lowerBounds, out upperBounds);
            int[] lengths = new int[rank];
            for (int i = 0; i < rank; i++)
                lengths[i] = upperBounds[i] - lowerBounds[i] + 1;

            Type elementType = Type.GetElementType();
            Array result = Array.CreateInstance(elementType, lengths, lowerBounds);


            do
            {
                ObjectBase element = (ObjectBase) arr.GetValue(dimensions);

                result.SetValue(element.GetValue(), dimensions);
            } while (IncreaseDimension(dimensions, lowerBounds, upperBounds, rank - 1));


            return result;
        }

        public void Build(SerializerEngine engine, Array item)
        {
            int rank;
            int[] dimensions;
            int[] lowerBounds;
            int[] upperBounds;
            SetupLoopData(item, out rank, out dimensions, out lowerBounds, out upperBounds);
            int[] lengths = new int[rank];
            for (int i = 0; i < rank; i++)
                lengths[i] = upperBounds[i] - lowerBounds[i] + 1;

            Items = Array.CreateInstance(typeof (ObjectBase), lengths, lowerBounds);
            Array arr = Items;

            do
            {
                object rawValue = item.GetValue(dimensions);
                ObjectBase obj = engine.GetObject(rawValue);
                arr.SetValue(obj, dimensions);
            } while (IncreaseDimension(dimensions, lowerBounds, upperBounds, rank - 1));
        }
    }
}