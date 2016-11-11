using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Rico.Aspnet.Samples.Common
{
    public class BasePage:Page
    {
        /// <summary>
        /// 提示对话框
        /// </summary>
        /// <param name="strMsg"></param>
        protected void MsgBox(string strMsg)
        {
            const string RegisterJS = "alert('{0}');";
            Page.ClientScript.RegisterStartupScript(GetType(), "StartupAlert", string.Format(RegisterJS, strMsg), true);

        }
    }
}