using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Rico.IOC.UnitySample
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建容器  
            IUnityContainer container = new UnityContainer();
            //注册映射  
            container.RegisterType<IKiss, Boy>();
            //得到Boy的实例  
            var boy = container.Resolve<IKiss>();

            Lily lily = new Lily(boy);
            lily.Kiss();

            Console.ReadKey();
        }
    }
}
