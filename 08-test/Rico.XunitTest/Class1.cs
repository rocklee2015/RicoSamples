﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rico.XunitTest
{
    
    public class Class1
    {
        [Fact]
        public void Test1()
        {
           Assert.Equal(1,1);
        }
    }
}
