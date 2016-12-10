using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Rico.Aspnet.Samples
{
    public partial class Send : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType == "POST")
            {
                //声明一个XMLDoc文档对象，LOAD（）xml字符串
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<entity><version>1.2.0_2012_12_05</version></entity>");
                //把XML发送出去

                Response.Write(doc.InnerXml);
                Response.End();
                Response.Redirect("Accept.aspx");
            }
        }
    }
}