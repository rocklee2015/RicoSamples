using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples
{
    class EnumMain
    {
        public static void ExcuteMain()
        {
            Console.WriteLine(Week.Friday.ToString());
        }
    }

    enum Week
    {
        Monday=1,
        Tuesth=2,
        Wednesday=3,
        Thursday=4,
        Friday=5,
        Saturday=6,
        Sunday=7
    }
}
