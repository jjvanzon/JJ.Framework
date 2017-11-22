using System.ServiceModel;

namespace JJ.Framework.Soap.Tests.ServiceInterface
{
	[ServiceContract]
	public interface ITestService
	{
		[OperationContract]
		CompositeType GetCompositeObject();

		[OperationContract]
		TypeWithCollection GetObjectWithCollection();

		[OperationContract]
		void SendCompositeObject(CompositeType compositeObject);

		[OperationContract]
		void SendObjectWithCollection(TypeWithCollection objectWithCollection);

		[OperationContract]
		CompositeType SendAndGetCompositeObject(CompositeType compositeObject);

		[OperationContract]
		TypeWithCollection SendAndGetObjectWithCollection(TypeWithCollection objectWithCollection);

		[OperationContract]
		void SendStringValue(string stringValue);

		[OperationContract]
		string GetStringValue();

		[OperationContract]
		string SendAndGetStringValue(string stringValue);

		[OperationContract]
		ComplicatedType SendAndGetComplicatedObject(ComplicatedType complicatedObject);
	}
}
