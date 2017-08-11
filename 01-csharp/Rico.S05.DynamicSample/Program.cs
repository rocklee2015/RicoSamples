using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S05.DynamicSample
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic aobj = new ExpandoObject();//创建运行时解析的对象，用于传递A类型计算方法的参数  
            aobj.monthnum = 30;
            aobj.monthprice = 6000;
            aobj.Commissionpric = 3000;

            Calculate cs = new Calculate(aobj);
            double aprice = cs.AtypRental();
            Console.WriteLine("A类型计算结果：" + aprice);

            dynamic bobj = new ExpandoObject();//创建运行时解析的对象，用于传递B类型计算方法的参数  
            aobj.daynum = 300;
            aobj.dayprice = 30;

            Calculate cs2 = new Calculate(aobj);
            double bprice = cs2.BtypRental();
            Console.WriteLine("B类型计算结果：" + bprice);

            //在通过 dynamic 类型实现的操作中，该类型的作用是绕过编译时类型检查，改为在运行时解析这些操作。  
            //dynamic 类型简化了对 COM API（例如 Office Automation API）、动态 API（例如 IronPython 库）和   
            //HTML 文档对象模型 (DOM) 的访问。  

            //所有我们在使用dynamic时类型进行参数传递时候要做好变量名称的约束。  
        }
    }
}
