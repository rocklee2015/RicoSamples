using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rico.AspNetWebForm
{
    public partial class FirstForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //asp.net WebForm 事件响应模型
            //http://blog.csdn.net/ydm19891101/article/details/50552611
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Text = "单击了事件";
        }
        protected void Button1_Click2(object sender, EventArgs e)
        {
            Button1.Text = "单击了事件2";
        }
        protected void Button1_Click(object sender,EventArgs e,string a)
        {
            Button1.Text = "单击了事件3";
        }
    }
}