using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.Csharp.DesignPattern.CreationalPattern.FactoryMethod;
using Rico.Csharp.DesignPattern.CreationalPattern.SimpleFactory;

namespace Rico.Csharp.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleFactoryPattern.Calculator();

            FactoryMethodPattern.Calculator();

            Console.ReadKey();
        }
    }
}
