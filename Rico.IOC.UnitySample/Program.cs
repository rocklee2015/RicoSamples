using System;
using Rico.IOC.UnitySample.Unity1;
using Rico.IOC.UnitySample.Unity2;

namespace Rico.IOC.UnitySample
{
    class Program
    {
        static void Main(string[] args)
        {
            //-------Sample One-------
            //Unity1Main.SimpleTest();
            //Unity1Main.TypeMapTest();
            Unity1Main.SinglePatternTest();
            Unity1Main.DependencyInjectionSingleConstructorTest();
            Unity1Main.DependencyInjectionMultipleConstructorTest();
            Unity1Main.DependencyInjectionPropertyInjectionTest();

            //Sample Two
            //Unity2Main.SimpleTest();
            Console.ReadKey();
        }
    }
}
