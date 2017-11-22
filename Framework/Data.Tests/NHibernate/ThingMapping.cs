using FluentNHibernate.Mapping;
using JJ.Framework.Data.Tests.Model;

namespace JJ.Framework.Data.Tests.NHibernate
{
	public class ThingMapping : ClassMap<Thing>
	{
		public ThingMapping()
		{
			Id(x => x.ID);
			Map(x => x.Name);
		}
	}
}