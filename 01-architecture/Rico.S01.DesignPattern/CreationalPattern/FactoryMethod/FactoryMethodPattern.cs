﻿using System;
using Rico.S01.DesignPattern.CreationalPattern.SimpleFactory;

namespace Rico.S01.DesignPattern.CreationalPattern.FactoryMethod
{
    public class FactoryMethodPattern
    {
        public static void Calculator()
        {
            IFactory operFactory = new AddFactory();
            Operation oper = operFactory.CreateOperation();
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();

            Console.WriteLine(result);

        }
    }
}
