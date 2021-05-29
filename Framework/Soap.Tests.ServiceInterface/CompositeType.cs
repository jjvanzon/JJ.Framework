using System.Runtime.Serialization;

namespace JJ.Framework.Soap.Tests.ServiceInterface
{
    [DataContract]
    public class CompositeType
    {
        [DataMember]
        public bool BoolValue { get; set; }

        [DataMember]
        public string StringValue { get; set; }
    }
}
