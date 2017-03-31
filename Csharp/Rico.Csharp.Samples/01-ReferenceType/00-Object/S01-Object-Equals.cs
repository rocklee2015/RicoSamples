using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples.ObjectEquals
{
    class EqualsMain
    {
        public void ExcuteMain()
        {
            var obj1=new EqualsMain();
            var obj2 = obj1;
            var result=Equals(obj1, obj2);
        }
    }
}
