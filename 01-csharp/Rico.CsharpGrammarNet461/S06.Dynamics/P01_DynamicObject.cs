using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S05.DynamicSample
{
    [TestClass]
    public class DynamicObjectTest
    {
       
        /// <summary>
        /// 动态添加属性
        /// </summary>
        [TestMethod]
        public  void UseSetMethod_Assign_StringValue_Return_Success()
        {
            dynamic dynamicObject = new MyDynamicObject();
            string @a = "Name";
            dynamicObject.set(@a, "ricolee");

            Assert.AreEqual("ricolee",dynamicObject.Name);
        }

        /// <summary>
        /// 动态添加属性,索引
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RuntimeBinderException))]
        public void UseIndex_Assign_StringValue_ThrowException()
        {
            dynamic dynamicObject = new MyDynamicObject();
            string @a = "Name";
            dynamicObject[@a] = "ricolee";
            Assert.AreEqual("ricolee", dynamicObject.Name);
        }

        /// <summary>
        /// dynamic 无法通过GetProperties获取其属性列表
        /// </summary>
        [TestMethod]
        public void Foreach_DynamicPropertys_Return_0()
        {
            dynamic dynamicObject = new MyDynamicObject();
            string @a = "Name";
            dynamicObject.set(@a, "rocklee");

            var result = typeof(MyDynamicObject).GetProperties().Select(i => i.Name).ToList();
            Console.WriteLine("SSSS");
            Trace.WriteLine("SSSS");
            Trace.TraceInformation("SSS");
            System.Diagnostics.Debug.WriteLine("aaaa");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(result.Count==0);
        }
    }

    /// <summary>
    /// 动态添加属性
    /// </summary>
    class MyDynamicObject : System.Dynamic.DynamicObject
    {
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            if (map != null)
            {
                string name = binder.Name;
                object value;
                if (map.TryGetValue(name, out value))
                {
                    result = value;
                    return true;
                }
            }
            return base.TryGetMember(binder, out result);
        }

        System.Collections.Generic.Dictionary<string, object> map;

        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name == "set" && binder.CallInfo.ArgumentCount == 2)
            {
                string name = args[0] as string;
                if (name == null)
                {
                    //throw new ArgumentException("name");  
                    result = null;
                    return false;
                }
                if (map == null)
                {
                    map = new System.Collections.Generic.Dictionary<string, object>();
                }
                object value = args[1];
                map.Add(name, value);
                result = value;
                return true;

            }
            return base.TryInvokeMember(binder, args, out result);
        }
    }
}
