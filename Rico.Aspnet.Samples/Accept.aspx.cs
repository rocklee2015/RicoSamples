using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rico.Aspnet.Samples
{
    public partial class Accept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType == "POST")
            {
                //接收并读取POST过来的XML文件流
                StreamReader reader = new StreamReader(Request.InputStream);
                String xmlData = reader.ReadToEnd();
                //把数据重新返回给客户端
                Response.Write(xmlData);
                Response.End();
            }
        }
    }
}