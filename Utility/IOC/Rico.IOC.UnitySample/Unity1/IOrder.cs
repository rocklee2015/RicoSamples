﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.UnitySample.Unity1
{
    public interface IOrder
    {
        double Discount { get; set; }
        void DumpDiscount();
    }
}