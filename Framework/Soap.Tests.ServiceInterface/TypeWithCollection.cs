using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JJ.Framework.Soap.Tests.ServiceInterface
{
	[DataContract]
	public class TypeWithCollection
	{
		[DataMember]
		public IList<string> StringList { get; set; }
	}
}
