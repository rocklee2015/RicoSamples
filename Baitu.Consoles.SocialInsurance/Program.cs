﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitu.Consoles.SocialInsurance
{
    class Program
    {
        static void Main(string[] args)
        {
            //2016-12-10
            var orderGroup = new OrderGroupByTimeAndDistrict();
            orderGroup.Excute();

            Console.ReadKey();
        }
    }


}
