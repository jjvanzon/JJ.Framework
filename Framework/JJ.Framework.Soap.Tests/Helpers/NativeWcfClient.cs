using JJ.Framework.Soap.Tests.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Soap.Tests.Helpers
{
    internal class NativeWcfClient : ClientBase<ITestService>, ITestService
    {
        public NativeWcfClient(string url)
            : base(new BasicHttpBinding(), new EndpointAddress(url))
        {
            Endpoint.EndpointBehaviors.Add(new NativeWcfClientMessageInspector());
        }

        public ComplicatedType SendAndGetComplicatedObject(ComplicatedType complicatedObject)
        {
            ComplicatedType complicatedObject2 = Channel.SendAndGetComplicatedObject(complicatedObject);
            return complicatedObject2;
        }

        public CompositeType GetCompositeObject()
        {
            throw new NotImplementedException();
        }

        public TypeWithCollection GetObjectWithCollection()
        {
            throw new NotImplementedException();
        }

        public void SendCompositeObject(CompositeType compositeObject)
        {
            throw new NotImplementedException();
        }

        public void SendObjectWithCollection(TypeWithCollection objectWithCollection)
        {
            throw new NotImplementedException();
        }

        public CompositeType SendAndGetCompositeObject(CompositeType compositeObject)
        {
            throw new NotImplementedException();
        }

        public TypeWithCollection SendAndGetObjectWithCollection(TypeWithCollection objectWithCollection)
        {
            throw new NotImplementedException();
        }

        public void SendStringValue(string stringValue)
        {
            throw new NotImplementedException();
        }

        public string GetStringValue()
        {
            throw new NotImplementedException();
        }

        public string SendAndGetStringValue(string stringValue)
        {
            throw new NotImplementedException();
        }
    }
}
