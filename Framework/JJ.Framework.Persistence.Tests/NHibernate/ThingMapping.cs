using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using JJ.Framework.Persistence.Tests.Model;

namespace JJ.Framework.Persistence.Tests.NHibernate
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