using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Soap.Tests.ServiceInterface
{
    [DataContract]
    public class TypeWithCollection
    {
        [DataMember]
        public IList<string> StringList { get; set; }
    }
}
