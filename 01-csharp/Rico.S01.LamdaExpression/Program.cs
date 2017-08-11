using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S01.LamdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //**********LamdaExpression lamda表达式
            LamdaExpressionMain.CreateExpressionByApi();        //API创建表达式树
            LamdaExpressionMain.CreateExpressionByLamda();      //Lamad 创建表达式树
            LamdaExpressionMain.ExcuteExpression();             //表达式树执行
            LamdaExpressionMain.CreateComplexLamdaExpression(); //复杂的表达式树
            LamdaExpressionMain.AnalyzeLamdaExpression();       //分析表达式树
        }
    }
}
