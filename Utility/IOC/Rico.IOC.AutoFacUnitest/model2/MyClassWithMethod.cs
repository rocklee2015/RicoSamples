using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.AutoFacUnitest.model2
{
    public class MyClassWithMethod
    {
        public int Index { get; set; }
        public void Add(int value)
        {
            Index = Index + value;
        }
    }
}
