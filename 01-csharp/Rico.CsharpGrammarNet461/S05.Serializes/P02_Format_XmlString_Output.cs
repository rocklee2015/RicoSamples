﻿using System;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S04.SerializeSample
{
    [TestClass]
    public class Format_XmlString_Output
    {
        /// <summary>
        /// 返回一个格式化的xml字符串
        /// </summary>
        [TestMethod]
        public void XmlString_Output_Return_Format_String()
        {
            var xmlString = "<!--?xml version=\"1.0\" encoding=\"utf - 8\"?-->" +
                "<serviceresponse><requestprocessed>TRUE</requestprocessed><message><rowset><row><aae013>通过</aae013><cac191>9</cac191><aac067>17682303751</aac067><baz838>2001</baz838><cac013>411422</cac013><aac010>河南省商丘市睢县董店乡田花园村16号</aac010><cac014>330110</cac014><aae006>浙江省杭州市余杭区横板桥社区35号404</aae006><cac043>330106</cac043><cac045>文一西路522号西溪软件园4号楼2单位一楼百图科技</cac045><aac005>01</aac005><aab099>99991231</aab099><bza502>3311220000</bza502><zp1>/9j/4gAaYWxpcAABAQE0UqYBTgIAAAAAAAAAAAAA/+AAEEpGSUYAAQEAAAEAAQAA /9sAQwAIDw8SDxIVFRUVFRUZFxkaGhoZGRkZGhoaHBwcISEhHBwcGhocHB8fISEk JCQiIiEiJCQmJiYuLiwsNjY4QkJQ/9sAQwEQEREXFBctGRktXz82P19fX19fX19f X19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19f/8AAEQgC TgGmAwEiAAIRAQMRAf/EABwAAAEFAQEBAAAAAAAAAAAAAAABAgMEBQYHCP/EAEQQ AAIBAgQDBQcCBAMGBQUAAAABAgMRBCExQRJRYXGBkaHwBRMiMrHB0eHxBhRCUiNi chUzQ4KSokRTY7LCJCU0g6P/xAAYAQEBAQEBAAAAAAAAAAAAAAAAAQIDBP/EACER AQEBAAMBAQACAwEAAAAAAAABEQIhMUESA2ETUXEi/9oADAMBAAIRAxEAPwD1FJWF shVoKVk2y5BZCigN</zp1></row></rowset></message></serviceresponse>";
            var result = FormatXml(xmlString);
            Console.WriteLine(result);
        }

        /// <summary>
        /// 格式化输出xml字符串
        /// </summary>
        /// <param name="sUnformattedXml"></param>
        /// <returns></returns>
        public string FormatXml(string sUnformattedXml)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;
            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 1;
                xtw.IndentChar = '\t';
                xd.WriteTo(xtw);
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
            }
            return sb.ToString();
        }
    }
}
