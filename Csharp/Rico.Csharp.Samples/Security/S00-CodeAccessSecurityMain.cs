using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples.Security
{
    class CodeAccessSecurityMain
    {
        public static void ExcuteMain()
        {
            System.Security.Policy.Evidence e = Assembly.GetExecutingAssembly().Evidence;

            IEnumerator enumerator = e.GetHostEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
