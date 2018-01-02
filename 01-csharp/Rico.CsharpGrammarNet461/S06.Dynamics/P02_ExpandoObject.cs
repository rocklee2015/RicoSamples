using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Dynamic;

namespace Rico.S05.DynamicSample
{
    /*
      在通过 dynamic 类型实现的操作中，该类型的作用是绕过编译时类型检查，改为在运行时解析这些操作。  
      dynamic 类型简化了对 COM API（例如 Office Automation API）、动态 API（例如 IronPython 库）和   
      HTML 文档对象模型 (DOM) 的访问。  
      所有我们在使用dynamic时类型进行参数传递时候要做好变量名称的约束。  
    */
    [TestClass]
    public class ExpandoObjectTest
    {
        [TestMethod]
        public void AtypeRental_Return_Success()
        {
            dynamic dynamicObj = new ExpandoObject();//创建运行时解析的对象，用于传递A类型计算方法的参数  
            dynamicObj.monthnum = 30;
            dynamicObj.monthprice = 6000;
            dynamicObj.Commissionpric = 3000;

            Calculate cs = new Calculate(dynamicObj);

            double aprice = cs.AtypeRental();

            Assert.AreEqual(183000, aprice);

            Console.WriteLine("A类型计算结果：" + aprice);

           
        }
        [TestMethod]
        public void BtypeRental_Return_Success()
        {
            dynamic dynamicObj = new ExpandoObject();//创建运行时解析的对象，用于传递B类型计算方法的参数  
            dynamicObj.daynum = 300;
            dynamicObj.dayprice = 30;

            Calculate calculate = new Calculate(dynamicObj);

            double bprice = calculate.BtypeRental();

            Assert.AreEqual(9000, bprice);

            Console.WriteLine("B类型计算结果：" + bprice);
        }
    }



    public class Calculate
    {
        /// <summary>  
        /// 运行时的参数传递对象  
        /// </summary>  
        private dynamic _obj;

        public Calculate(dynamic obj)
        {
            this._obj = obj;
        }

        /// <summary>  
        /// A类型算法的计算租金=monthnum*monthprice+Commissionpric  
        /// </summary>  
        public double AtypeRental()
        {
            //租金=monthnum * monthprice + Commissionpric  
            return (int)this._obj.monthnum * (double)this._obj.monthprice + (double)this._obj.Commissionpric;
        }

        /// <summary>  
        /// B类型算法租金=daynum*dayprice  
        /// </summary>  
        public double BtypeRental()
        {
            //租金=daynum * dayprice  
            return (int)this._obj.daynum * (double)this._obj.dayprice;
        }
    }

}
