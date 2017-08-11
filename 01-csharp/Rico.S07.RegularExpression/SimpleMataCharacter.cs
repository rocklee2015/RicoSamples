using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rico.S07.RegularExpression
{
    class SimpleMataCharacter
    {
        /// <summary>
        /// 简单的元字符
        /// </summary>
        public static void EasyMetaCharacters()
        {
            //脱字符 ^   ：表示匹配行首的文本
            //美元符  $　：表示匹配行尾的文本

            //^cat  匹配以c作为一行的第一个字符是c，然后是一个a，紧接着一个t的文本
            //例如一个行　　catdogcat　　上面正则表达式匹配第一个cat。

            //特殊正则说明：
            //^cat$     匹配行开头是cat，然后就是行末尾的cat，说白了就是一行中仅仅只包含cat的行，没有其他字符。
            //^$        匹配行开头，然后就是行末尾了，说白了就是匹配一个空行(没有任何字符，也没有空白字符)
            //^         匹配行的开头，每一行都匹配

            Regex reg = new Regex("^cat");
            reg.Match("catdog");
            Console.WriteLine(reg.Match("catdog"));     //输出 cat
            Console.WriteLine(reg.Match("dogcat"));     //输出 空白(啥都不输出)

            Regex reg2 = new Regex("cat$");
            Console.WriteLine(reg2.Match("catdog"));      //输出 空白(啥都不输出)
            Console.WriteLine(reg2.Match("dogcat"));      //输出 cat
        }
    }
}
