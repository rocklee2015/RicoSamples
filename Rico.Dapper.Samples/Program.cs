using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Dapper.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new DapperDemo();
            demo.OneToOne();
        }
     
    }
}
