﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.ThreadBookSamples.C9_AsynchronouseIO;

namespace Rico.ThreadBookSamples
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //ThreadNonsyncCode.Execute();

            //S4AccessDataBaseAsync.ExcuteMain();

            S4AccessDataBaseAsync.ExcuteMain();
            Console.ReadKey();
        }
    }
}