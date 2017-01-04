using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.AutoFacUnitest.model2
{
    public class ClassA
    {
        private readonly ClassB b;

        public ClassA(ClassB b)
        {
            this.b = b;
        }
    }

    public class ClassB
    {
        public ClassA A { get; set; }

    }
}
