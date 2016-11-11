using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rico.Aspnet.Samples.Common;
namespace Rico.Aspnet.Samples
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsgBox("加载成功！");
        }
    }
}