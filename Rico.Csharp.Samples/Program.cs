using Rico.Csharp.Samples.LamdaExpression;
using Rico.Csharp.Samples.RegularExpression;
using Rico.Csharp.Samples.Serialize;
using Rico.Csharp.Samples.StringSample;

namespace Rico.Csharp.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Serialize 序列化
            SerializeMain.SerializeDictionnary();

            //Regular  正则表达式
            RegularMain.EasyMetaCharacters();

            //LamdaExpression lamda表达式
            LamdaExpressionMain.LamdaExpression_Create();

            //String 字符串操作
            
        }
    }
}
