using System;
using System.Collections;
using System.Collections.Generic;
using KumoUnitTests.Interceptors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using TestProject1.Aspects;
using System.Reflection;

namespace KumoUnitTests
{
    [TestClass()]
    public class Tests
    {
        [TestMethod()]
        public void ProxyExplicitIFace()
        {
            Engine c = new Engine("ProxyExplicitIFace");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ProxyExplicitIFace", typeof (SomeClassWithExplicitIFace), "*Clone*"
                                    /*<-only Clone */, new ExplicitIFaceClonableInterceptor()));

            SomeClassWithExplicitIFace proxy =
                (SomeClassWithExplicitIFace) c.CreateProxy(typeof (SomeClassWithExplicitIFace));

            ICloneable cloneable = proxy;

            SomeClassWithExplicitIFace res = (SomeClassWithExplicitIFace) cloneable.Clone();

            Assert.IsTrue(res.SomeLongProp == 1234, "Clone interceptor did not work");
        }

        [TestMethod()]
        public void MixinInArrayList()
        {
            Engine c = new Engine("MixinInArrayList");

            c.Configuration.Aspects.Add(
                new SignatureAspect("AddInterface", typeof (ArrayList), new Type[] {typeof (SayHelloMixin)},
                                    new IPointcut[0]));

            ArrayList proxy = (ArrayList) c.CreateProxy(typeof (ArrayList));

            ISayHello sayHello = (ISayHello) proxy;

            string helloString = sayHello.SayHello();

            Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");
        }

        [TestMethod()]
        public void MixinInOverlappingNames()
        {
            Engine c = new Engine("MixinInOverlappingNames");

            c.Configuration.Aspects.Add(
                new SignatureAspect("MixinInOverlappingNames", typeof(Foo), new Type[] { typeof(Iface1Mixin), typeof(Iface2Mixin) },
                                    new IPointcut[0]));

            Foo proxy = (Foo)c.CreateProxy(typeof(Foo));

            Iface1 m1 = (Iface1)proxy;
            Iface2 m2 = (Iface2)proxy;
            

            Assert.IsTrue(m1.SomeMethod () == 1, "mixin1 did not return the correct value");
            Assert.IsTrue(m2.SomeMethod() == 2, "mixin2 did not return the correct value");
        }

        [TestMethod()]
        public void MixinInWOIface()
        {
            Engine c = new Engine("MixinInWOIface");

            c.Configuration.Aspects.Add(
                new SignatureAspect("MixinInWOIface", typeof(Foo), new Type[] { typeof(MixinWOIface) },
                                    new IPointcut[0]));

            Foo proxy = (Foo)c.CreateProxy(typeof(Foo));

            
        }

        [TestMethod()]
        public void MixinInterfaceWOImplementation()
        {
            Engine c = new Engine("MixinInterfaceWOImplementation");

            c.Configuration.Aspects.Add(
                new SignatureAspect("AddInterface", typeof (ArrayList),
                                    new Type[] {typeof (ISomeListMarkerIFace), typeof (SayHelloMixin)}, new IPointcut[0]));

            ArrayList proxy = (ArrayList) c.CreateProxy(typeof (ArrayList));

            ISayHello sayHello = (ISayHello) proxy;

            string helloString = sayHello.SayHello();

            Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");

            Assert.IsTrue(proxy is ISomeListMarkerIFace, "Marker interface was not applied to type");
        }

        [TestMethod()]
        public void MixinInGenericList()
        {
            Engine c = new Engine("MixinInGenericList");

            c.Configuration.Aspects.Add(
                new SignatureAspect("AddInterface", typeof (List<string>), new Type[] {typeof (SayHelloMixin)},
                                    new IPointcut[0]));

            List<string> proxy = (List<string>) c.CreateProxy(typeof (List<string>));

            ISayHello sayHello = (ISayHello) proxy;

            string helloString = sayHello.SayHello();

            Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");
        }

        [TestMethod()]
        public void MixinInterfaceWOImplementationInGenericList()
        {
            Engine c = new Engine("MixinInterfaceWOImplementationInGenericList");

            c.Configuration.Aspects.Add(
                new SignatureAspect("AddInterface", typeof (List<string>),
                                    new Type[] {typeof (ISomeListMarkerIFace), typeof (SayHelloMixin)}, new IPointcut[0]));

            List<string> proxy = c.CreateProxy<List<string>>();

            ISayHello sayHello = (ISayHello) proxy;

            string helloString = sayHello.SayHello();

            Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");

            Assert.IsTrue(proxy is ISomeListMarkerIFace, "Marker interface was not applied to type");
        }

        [TestMethod()]
        public void ProxyGenericList()
        {
            Engine c = new Engine("ProxyGenericList");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ProxyGenericList", typeof (List<string>), "*Add*", new PassiveInterceptor()));

            List<string> proxy = c.CreateProxy<List<string>>();
            Assert.IsTrue(proxy != null, "Failed to proxy generic list");
            Assert.IsTrue(proxy is IAopProxy, "Failed to proxy generic list");

            proxy.Add("a");
            proxy.Add("b");
            proxy.Add("c");
            proxy.RemoveAt(0);
            proxy.Remove("b");

            IList ilist = proxy;
            ilist.Add("hej");
        }

        [TestMethod()]
        public void WrapGenericList()
        {
            Engine c = new Engine("WrapGenericList");
            c.Configuration.Aspects.Add(new SignatureAspect("WrapGenericList", typeof(List<string>), "*Add*", new PassiveInterceptor()));

            List<string> realList = new List<string>();

            IList<string> wrapperList = (IList<string>)c.CreateWrapper(realList);
            Assert.IsTrue(wrapperList != null, "Failed to proxy generic list");
            Assert.IsTrue(wrapperList is IAopProxy, "Failed to proxy generic list");

            wrapperList.Add("a");
            wrapperList.Add("b");
            wrapperList.Add("c");
            wrapperList.RemoveAt(0);
            wrapperList.Remove("b");
        }

        [TestMethod()]
        public void TypedAspectMixinTest()
        {
            Engine c = new Engine("TypedAspectMixinTest");
            c.Configuration.Aspects.Add(new MyTypedAspect());

            Foo proxy = (Foo)c.CreateProxy(typeof(Foo));

            ISayHello sayHello = (ISayHello)proxy;

            string helloString = sayHello.SayHello();

            Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");
        }

        [TestMethod()]
        public void TypedAspectInterceptorTest()
        {
            Engine c = new Engine("TypedAspectInterceptorTest");
            c.Configuration.Aspects.Add(new ReturnValueChangerAspect());

            Foo proxy = (Foo)c.CreateProxy(typeof(Foo));

            int result = proxy.MyIntMethod();

            Assert.IsTrue(result == 1, "return value has not been changed");
        }

        [TestMethod()]
        public void CustomAspectMatchOnGenericType()
        {
            Engine c = new Engine("CustomAspectMatchOnGenericType");
            CustomAspectOnGenericType myCustomAspect = new CustomAspectOnGenericType();
            myCustomAspect.Pointcuts.Add(new SignaturePointcut("*GetValue123*", new IncreaseReturnValueInterceptor()));
            c.Configuration.Aspects.Add(myCustomAspect);

            SomeGenericClass<string> someGenericStringClass = c.CreateProxy<SomeGenericClass<string>>();

            int valueOf123 = someGenericStringClass.GetValue123();

            Assert.IsTrue(valueOf123 == 124,
                          "IncreaseReturnValueInterceptor was not applied to GetValue123 method for SomeGenericClass<string>");

            int valueOf567 = someGenericStringClass.GetValue567();

            Assert.IsTrue(valueOf567 == 567,
                          "IncreaseReturnValueInterceptor was applied to GetValue567 method for SomeGenericClass<string>");


            SomeGenericClass<int> someGenericIntClass = c.CreateProxy<SomeGenericClass<int>>();

            valueOf123 = someGenericIntClass.GetValue123();

            Assert.IsTrue(valueOf123 == 123,
                          "IncreaseReturnValueInterceptor was applied to GetValue123 method for SomeGenericClass<int>");

            valueOf567 = someGenericIntClass.GetValue567();

            Assert.IsTrue(valueOf567 == 567,
                          "IncreaseReturnValueInterceptor was applied to GetValue567 method for SomeGenericClass<int>");
        }

        [TestMethod()]
        public void CustomAspectMatchOnGenericType_RefType()
        {
            Engine c = new Engine("CustomAspectMatchOnGenericType_RefType");
            CustomAspectOnGenericType_RefType myCustomAspect = new CustomAspectOnGenericType_RefType();
            myCustomAspect.Pointcuts.Add(new SignaturePointcut("*GetValue123*", new IncreaseReturnValueInterceptor()));
            c.Configuration.Aspects.Add(myCustomAspect);

            SomeGenericClass<string> someGenericStringClass = c.CreateProxy<SomeGenericClass<string>>();

            int valueOf123 = someGenericStringClass.GetValue123();

            Assert.IsTrue(valueOf123 == 124,
                          "IncreaseReturnValueInterceptor was not applied to GetValue123 method for SomeGenericClass<string>");

            int valueOf567 = someGenericStringClass.GetValue567();

            Assert.IsTrue(valueOf567 == 567,
                          "IncreaseReturnValueInterceptor was applied to GetValue567 method for SomeGenericClass<string>");


            SomeGenericClass<int> someGenericIntClass = c.CreateProxy<SomeGenericClass<int>>();

            valueOf123 = someGenericIntClass.GetValue123();

            Assert.IsTrue(valueOf123 == 123,
                          "IncreaseReturnValueInterceptor was applied to GetValue123 method for SomeGenericClass<int>");

            valueOf567 = someGenericIntClass.GetValue567();

            Assert.IsTrue(valueOf567 == 567,
                          "IncreaseReturnValueInterceptor was applied to GetValue567 method for SomeGenericClass<int>");
        }


        [TestMethod()]
        public void DoubleProxy2Container()
        {
            Engine e1 = new Engine("DoubleProxy2Container1");
            Engine e2 = new Engine("DoubleProxy2Container2");
            e1.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof (Foo), "MyInt*", new IncreaseReturnValueInterceptor()));
            e2.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof (Foo), "MyInt*", new IncreaseReturnValueInterceptor()));

            Type proxyType = e1.CreateProxyType(typeof (Foo));

            //note the "null" param is the state that was supposed to come from the previous level of proxying
            Foo proxy = (Foo) e2.CreateProxy(proxyType, null);

            Assert.IsTrue(proxy != null, "failed to create proxified instance");
            int result = proxy.MyIntMethod();

            Assert.IsTrue(result == 2, "return value has not been changed");
        }

        [TestMethod()]
        public void DoubleProxy2ContainerExtend()
        {
            Engine e1 = new Engine("DoubleProxy2ContainerExtend1");
            Engine e2 = new Engine("DoubleProxy2ContainerExtend2");
            e1.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof(Foo), "MyInt*", new IncreaseReturnValueInterceptor()));
           
            Type proxyType = e1.CreateProxyType(typeof(Foo));
            //note the "null" param is the state that was supposed to come from the previous level of proxying
            Foo proxy = (Foo)e2.CreateProxy(proxyType, null);

            Assert.IsTrue(proxy != null, "failed to create proxified instance");
        }

        [TestMethod()]
        public void DoubleProxy1Container()
        {
            Engine e1 = new Engine("DoubleProxy1Container");
            e1.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof (Foo), "MyInt*", new IncreaseReturnValueInterceptor()));

            Type proxyType = e1.CreateProxyType(typeof (Foo));
            Foo proxy = (Foo) e1.CreateProxy(proxyType, null);

            Assert.IsTrue(proxy != null, "failed to create proxified instance");
            int result = proxy.MyIntMethod();

            Assert.IsTrue(result == 2, "return value has not been changed");
        }

        [TestMethod()]
        public void CreateProxyWithInterceptor()
        {
            Engine c = new Engine("CreateProxyWithInterceptor");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof (Foo), "*", new ChangeReturnValueInterceptor()));

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            Assert.IsTrue(proxy != null, "failed to create proxified instance");
        }

        [TestMethod()]
        public void CreateProxyWithCtorParamsWithInterceptor()
        {
            Engine c = new Engine("CreateProxyWithCtorParamsWithInterceptor");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof (Foo), "*", new ChangeReturnValueInterceptor()));

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo), 555, "hello");

            Assert.IsTrue(proxy != null, "failed to create proxified instance");
        }

        [TestMethod()]
        public void CreateProxy()
        {
            Engine c = new Engine("CreateProxy");

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            Assert.IsTrue(proxy != null, "failed to create proxified instance");
        }

        [TestMethod()]
        public void CreateProxyWithCtorParams()
        {
            Engine c = new Engine("CreateProxyWithCtorParams");

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo), 555, "hello");

            Assert.IsTrue(proxy != null, "failed to create proxified instance");
        }

        [TestMethod()]
        public void ChangeReturnValue()
        {
            Engine c = new Engine("ChangeReturnValue");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof (Foo), "*", new ChangeReturnValueInterceptor()));

            Foo normal = new Foo();

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            Assert.IsTrue(normal.MyIntMethod() != proxy.MyIntMethod(), "return value has not been changed");
        }

        [TestMethod()]
        public void ChangeRefParam()
        {
            Engine c = new Engine("ChangeRefParam");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ChangeRefParam", typeof (Foo), "*MyRefParamMethod*",
                                    new ChangeRefParamValueInterceptor()));

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            string refString = "some value";
            proxy.MyRefParamMethod(ref refString);

            Assert.IsTrue("some value" != refString, "ref param has not been changed");
            Assert.IsTrue("some changed value" == refString, "ref param has not been set correctly");
        }

        [TestMethod()]
        public void PassAndReturnRefParam()
        {
            Engine c = new Engine("PassAndReturnRefParam");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ChangeRefParam", typeof (Foo), "*PassAndReturnRefParam*",
                                    new ChangeRefParamValueInterceptor()));
            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            string refString = "some value";
            string result = proxy.PassAndReturnRefParam(ref refString);

            Assert.IsTrue("some value" == result, "ref param has not been passed and returned correctly");
            Assert.IsTrue("some changed value" == refString, "ref param has not been passed and returned correctly");
        }

        [TestMethod()]
        public void PointcutTargetMatch()
        {
            Engine c = new Engine("PointcutTargetMatch");
            c.Configuration.Aspects.Add(
                new SignatureAspect("ChangeReturnValue", typeof (Foo), "*MyIntMethod*" /*<-only MyIntMethod */,
                                    new ChangeReturnValueInterceptor()));

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            Assert.IsTrue(proxy.MyIntMethod() != 0, "return value has not been changed");
            Assert.IsTrue(proxy.MyOtherIntMethod() == 0, "return value has been changed");
        }

        [TestMethod()]
        public void RemoveException()
        {
            Engine c = new Engine("RemoveException");
            c.Configuration.Aspects.Add(
                new SignatureAspect("RemoveException", typeof (Foo), "*", new RemoveExceptionInterceptor()));

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            proxy.MyExceptionMethod();
        }

        [TestMethod()]
        [ExpectedException(typeof (NullReferenceException), "added exception")]
        public void AddException()
        {
            Engine c = new Engine("AddException");
            c.Configuration.Aspects.Add(
                new SignatureAspect("RemoveException", typeof (Foo), "*", new AddExceptionInterceptor()));

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            proxy.MyExceptionMethod();
        }

        [TestMethod()]
        [ExpectedException(typeof (NullReferenceException), "added exception")]
        public void AddExceptionWithMultipleInterceptors()
        {
            Engine c = new Engine("AddExceptionWithMultipleInterceptors");
            c.Configuration.Aspects.Add(new SignatureAspect("Security", typeof (Foo), "*", new SecurityInterceptor()));
            c.Configuration.Aspects.Add(
                new SignatureAspect("Invariant", typeof (Foo), "*MyExceptionMethod*", new InvariantInterceptor()));
            c.Configuration.Aspects.Add(
                new SignatureAspect("RemoveException", typeof (Foo), "*MyExceptionMethod*",
                                    new AddExceptionInterceptor()));

            Foo proxy = c.CreateProxy<Foo>();

            proxy.MyExceptionMethod();
        }

        [TestMethod()]
        public void MixinTest()
        {
            Engine c = new Engine("MixinTest");
            c.Configuration.Aspects.Add(
                new SignatureAspect("MixinTest", typeof (Foo), new Type[] {typeof (SayHelloMixin)}, new IPointcut[0]));

            Foo proxy = (Foo) c.CreateProxy(typeof (Foo));

            ISayHello sayHello = (ISayHello) proxy;

            string helloString = sayHello.SayHello();

            Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");
        }


        [TestMethod()]
        public void ExtendingProperties()
        {
            Engine c = new Engine("ExtendingProperties");

            SignatureAspect aspect = new SignatureAspect("PropertyAdder", typeof(Foo), new Type[] { }, new IPointcut[] { });

            TypeExtender extender = new TypeExtender();
            
            ExtendedProperty property1 = new ExtendedProperty();
            property1.Name = "MyIntProperty";
            property1.FieldName = "_MyIntProperty";
            property1.Type = typeof(int);
            extender.Members.Add(property1);

            ExtendedProperty property2 = new ExtendedProperty();
            property2.Name = "MyStringProperty";
            property2.FieldName = "_MyStringProperty";
            property2.Type = typeof(string);
            extender.Members.Add(property2);

            aspect.TypeExtenders.Add(extender);

            c.Configuration.Aspects.Add(aspect);                
            Foo proxy = (Foo)c.CreateProxy(typeof(Foo));

            PropertyInfo property1Info = proxy.GetType().GetProperty("MyIntProperty");
            PropertyInfo property2Info = proxy.GetType().GetProperty("MyStringProperty");

            Assert.IsNotNull(property1, "Property1 was not emitted");
            Assert.IsNotNull(property2, "Property2 was not emitted");


            property1Info.SetValue(proxy, 123, null);
            int resInt = (int)property1Info.GetValue(proxy, null);
            Assert.IsTrue(resInt == 123, "Property1 does not hold the correct value");


            property2Info.SetValue(proxy, "Hello", null);
            string resString = (string)property2Info.GetValue(proxy, null);
            Assert.IsTrue(resString == "Hello", "Property2 does not hold the correct value");

        }

        [TestMethod()]
        public void InterceptExtendedProperties()
        {
            Engine c = new Engine("InterceptExtendedProperties");

            SignatureAspect aspect = new SignatureAspect("PropertyAdder", typeof(Foo), new Type[] { }, new IPointcut[] { });
            aspect.Pointcuts.Add(new SignaturePointcut("get_MyIntProperty", new IncreaseReturnValueInterceptor()));

            TypeExtender extender = new TypeExtender();

            ExtendedProperty property1 = new ExtendedProperty();
            property1.Name = "MyIntProperty";
            property1.FieldName = "_MyIntProperty";
            property1.Type = typeof(int);
            extender.Members.Add(property1);

            aspect.TypeExtenders.Add(extender);

            c.Configuration.Aspects.Add(aspect);
            Foo proxy = (Foo)c.CreateProxy(typeof(Foo));

            PropertyInfo property1Info = proxy.GetType().GetProperty("MyIntProperty");

            Assert.IsNotNull(property1, "Property1 was not emitted");


            property1Info.SetValue(proxy, 123, null);
            int resInt = (int)property1Info.GetValue(proxy, null);
            Assert.IsTrue(resInt == 124, "Property1 Was not intercepted");         
        }
    }
}