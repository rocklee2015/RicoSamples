using System;

namespace Rico.S06.UnitySample.Unity2
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
