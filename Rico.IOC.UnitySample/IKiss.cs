using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.UnitySample
{
    public interface IKiss
    {  
        void Kiss();  
    }  
  
    public class Lily : IKiss  
    {  
        public IKiss boy;   
        public Lily(IKiss boy)
        {  
            this.boy=boy;  
        }  
        public void Kiss()
        {  
            boy.Kiss();  
            Console.WriteLine("lily kissing");  
        }
    }  
  
    public class Boy : IKiss  
    {  
        public void Kiss()
        {  
            Console.WriteLine("boy kissing");  
        }  
    }  

}
