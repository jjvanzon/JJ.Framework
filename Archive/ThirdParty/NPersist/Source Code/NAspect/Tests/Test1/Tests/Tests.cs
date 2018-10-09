using System;
using System.Collections;
using KumoUnitTests.Interceptors;
using NUnit.Framework;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;

namespace KumoUnitTests
{
	[TestFixture()]
	public class Tests
	{

		[Test()]
		public void DoubleProxy2Container()
		{
			Engine e1 = new Engine("DoubleProxy2Container1");
			Engine e2 = new Engine("DoubleProxy2Container2");
			e1.Configuration.Aspects.Add(new SignatureAspect("ChangeReturnValue", typeof (SomeClass), "MyInt*", new IncreaseReturnValueInterceptor()));
			e2.Configuration.Aspects.Add(new SignatureAspect("ChangeReturnValue", typeof (SomeClass), "MyInt*", new IncreaseReturnValueInterceptor()));

			Type proxyType = e1.CreateProxyType (typeof (SomeClass));

			//note the "null" param is the state that was supposed to come from the previous level of proxying
			SomeClass proxy = (SomeClass) e2.CreateProxy(proxyType,null);

			Assert.IsTrue(proxy != null, "failed to create proxified instance");
			int result = proxy.MyIntMethod() ;

			Assert.IsTrue(result == 2, "return value has not been changed");
		}

		[Test()]
		public void DoubleProxy1Container()
		{
			Engine e1 = new Engine("DoubleProxy1Container");			
			e1.Configuration.Aspects.Add(new SignatureAspect("ChangeReturnValue", typeof (SomeClass), "MyInt*", new IncreaseReturnValueInterceptor()));			

			Type proxyType = e1.CreateProxyType (typeof (SomeClass));
			SomeClass proxy = (SomeClass) e1.CreateProxy(proxyType,null);

			Assert.IsTrue(proxy != null, "failed to create proxified instance");
			int result = proxy.MyIntMethod() ;

			Assert.IsTrue(result == 2, "return value has not been changed");
		}

		[Test()]
		public void CreateProxyWithInterceptor()
		{
			Engine c = new Engine("CreateProxyWithInterceptor");
			c.Configuration.Aspects.Add(new SignatureAspect("ChangeReturnValue", typeof (SomeClass), "*", new ChangeReturnValueInterceptor()));

			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			Assert.IsTrue(proxy != null, "failed to create proxified instance");
		}

		[Test()]
		public void CreateProxyWithCtorParamsWithInterceptor()
		{
			Engine c = new Engine("CreateProxyWithCtorParamsWithInterceptor");
			c.Configuration.Aspects.Add(new SignatureAspect("ChangeReturnValue", typeof (SomeClass), "*", new ChangeReturnValueInterceptor()));

			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass),555,"hello");

			Assert.IsTrue(proxy != null, "failed to create proxified instance");
		}

		[Test()]
		public void CreateProxy()
		{
			Engine c = new Engine("CreateProxy");
		
			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			Assert.IsTrue(proxy != null, "failed to create proxified instance");
		}

		[Test()]
		public void CreateProxyWithCtorParams()
		{
			Engine c = new Engine("CreateProxyWithCtorParams");
		
			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass),555,"hello");

			Assert.IsTrue(proxy != null, "failed to create proxified instance");
		}

		[Test()]
		public void ChangeReturnValue()
		{
			Engine c = new Engine("ChangeReturnValue");
			c.Configuration.Aspects.Add(new SignatureAspect("ChangeReturnValue", typeof (SomeClass), "*", new ChangeReturnValueInterceptor()));

			SomeClass normal = new SomeClass();
			
			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			Assert.IsTrue(normal.MyIntMethod() != proxy.MyIntMethod(), "return value has not been changed");
		}

		[Test()]
		public void ChangeRefParam()
		{
			Engine c = new Engine("ChangeRefParam");
			c.Configuration.Aspects.Add(new SignatureAspect("ChangeRefParam", typeof (SomeClass), "*MyRefParamMethod*", new ChangeRefParamValueInterceptor()));

			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			string refString = "some value";
			proxy.MyRefParamMethod(ref refString);

			Assert.IsTrue("some value" != refString, "ref param has not been changed");
			Assert.IsTrue("some changed value" == refString, "ref param has not been set correctly");
		}

		[Test()]
		public void PassAndReturnRefParam()
		{
			Engine c = new Engine("PassAndReturnRefParam");
			c.Configuration.Aspects.Add(new SignatureAspect("ChangeRefParam", typeof (SomeClass), "*PassAndReturnRefParam*", new ChangeRefParamValueInterceptor()));
			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			string refString = "some value";
			string result = proxy.PassAndReturnRefParam(ref refString);

			Assert.IsTrue("some value" == result, "ref param has not been passed and returned correctly");
			Assert.IsTrue("some changed value" == refString, "ref param has not been passed and returned correctly");

		}

		[Test()]
		public void PointcutTargetMatch()
		{
			Engine c = new Engine("PointcutTargetMatch");
			c.Configuration.Aspects.Add(new SignatureAspect("ChangeReturnValue", typeof (SomeClass), "*MyIntMethod*" /*<-only MyIntMethod */, new ChangeReturnValueInterceptor()));

			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			Assert.IsTrue(proxy.MyIntMethod() != 0, "return value has not been changed");
			Assert.IsTrue(proxy.MyOtherIntMethod() == 0, "return value has been changed");
		}

		[Test()]
		public void RemoveException()
		{
			Engine c = new Engine("RemoveException");
			c.Configuration.Aspects.Add(new SignatureAspect("RemoveException", typeof (SomeClass), "*", new RemoveExceptionInterceptor()));

			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			proxy.MyExceptionMethod();
		}

		[Test()]
		[ExpectedException(typeof (Exception), "added exception")]
		public void AddException()
		{
			Engine c = new Engine("AddException");
			c.Configuration.Aspects.Add(new SignatureAspect("RemoveException", typeof (SomeClass), "*", new AddExceptionInterceptor()));

			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			proxy.MyExceptionMethod();
		}

		[Test()]
		public void MixinTest()
		{
			Engine c = new Engine("MixinTest");
			c.Configuration.Aspects.Add(new SignatureAspect("MixinTest", typeof (SomeClass), new Type[] {typeof (SayHelloMixin)}, new IPointcut[0]));

			SomeClass proxy = (SomeClass) c.CreateProxy(typeof (SomeClass));

			ISayHello sayHello = (ISayHello) proxy;

			string helloString = sayHello.SayHello();

			Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");
		}

		[Test()]
		public void ProxyExplicitIFace()
		{
			Engine c = new Engine("ProxyExplicitIFace");
			c.Configuration.Aspects.Add(new SignatureAspect("ProxyExplicitIFace", typeof (SomeClassWithExplicitIFace), "*Clone*" /*<-only Clone */, new ExplicitIFaceClonableInterceptor()));

			SomeClassWithExplicitIFace proxy = (SomeClassWithExplicitIFace) c.CreateProxy(typeof (SomeClassWithExplicitIFace));

			ICloneable cloneable = (ICloneable)proxy;

			SomeClassWithExplicitIFace res = (SomeClassWithExplicitIFace) cloneable.Clone() ;

			Assert.IsTrue(res.SomeLongProp == 1234,"Clone interceptor did not work") ;

		}

		[Test()]
		public void MixinInArrayList()
		{
			Engine c = new Engine("MixinInArrayList");

			c.Configuration.Aspects.Add (new SignatureAspect("AddInterface", typeof (ArrayList), new Type[] {typeof(SayHelloMixin)} ,new IPointcut[0] ));

			ArrayList proxy = (ArrayList) c.CreateProxy(typeof (ArrayList));

			ISayHello sayHello = (ISayHello) proxy;

			string helloString = sayHello.SayHello();

			Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");

		}

		[Test()]
		public void MixinInterfaceWOImplementation()
		{
			Engine c = new Engine("MixinInterfaceWOImplementation");

			c.Configuration.Aspects.Add (new SignatureAspect("AddInterface", typeof (ArrayList), new Type[] {typeof(ISomeListMarkerIFace),typeof(SayHelloMixin)} ,new IPointcut[0] ));

			ArrayList proxy = (ArrayList) c.CreateProxy(typeof (ArrayList));

			ISayHello sayHello = (ISayHello) proxy;

			string helloString = sayHello.SayHello();

			Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");

			Assert.IsTrue(proxy is ISomeListMarkerIFace,"Marker interface was not applied to type") ;
		}

		[Test()]
		public void CreateWrapper()
		{
			Engine c = new Engine("CreateWrapper");
			c.Configuration.Aspects.Add (new SignatureAspect("AddInterface", typeof (ArrayList), new Type[] {typeof(ISomeListMarkerIFace),typeof(SayHelloMixin)} ,new IPointcut[0] ));


			ArrayList realList = new ArrayList() ;
			IList wrapperList = (IList) c.CreateWrapper(realList);
			wrapperList.Add("apa");
			int cnt = wrapperList.Count;
		
			Assert.IsTrue(wrapperList is ISomeListMarkerIFace,"Marker interface was not applied to type") ;

			ISayHello sayHello = (ISayHello) wrapperList;
			string helloString = sayHello.SayHello();
			Assert.IsTrue(helloString == "Hello", "SayHelloMixin did not work");
		}
	}
}