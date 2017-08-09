﻿using System;
using System.Diagnostics;

namespace Rico.Csharp.Samples
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //**********Serialize 序列化
            //SerializeMain.SerializeDictionnary();

            //**********Regular  正则表达式
            //RegularMain.EasyMetaCharacters();

            //**********LamdaExpression lamda表达式
            //LamdaExpressionMain.CreateExpressionByApi();        //API创建表达式树
            //LamdaExpressionMain.CreateExpressionByLamda();      //Lamad 创建表达式树
            //LamdaExpressionMain.ExcuteExpression();             //表达式树执行
            //LamdaExpressionMain.CreateComplexLamdaExpression(); //复杂的表达式树
            //LamdaExpressionMain.AnalyzeLamdaExpression();       //分析表达式树


            //**********String 字符串操作
            //StringIntern.Test10();

            //EnumMain.ExcuteMain();

            //CodeAccessSecurityMain.ExcuteMain();

            //Trace.Assert(false,"有错误！");
            Trace.WriteLine("有错误！");
            Console.ReadKey();
        }

         static void Test2()
        {
            string str = "ab";
            str += "c";
            Console.WriteLine(String.IsInterned(str) ?? "null");  //null
        }
    }
}
