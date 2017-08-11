using System;

namespace Rico.S05.DynamicSample
{
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
        public double AtypRental()
        {
            Console.WriteLine("A类型算法的计算租金=monthnum*monthprice+Commissionpric");
            return (int)this._obj.monthnum * (double)this._obj.monthprice + (double)this._obj.Commissionpric;
        }

        /// <summary>  
        /// B类型算法租金=daynum*dayprice  
        /// </summary>  
        public double BtypRental()
        {
            Console.WriteLine("B类型算法租金=daynum*dayprice");
            return (int)this._obj.daynum * (double)this._obj.dayprice;
        }
    }
}
