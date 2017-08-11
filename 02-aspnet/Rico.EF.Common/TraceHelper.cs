using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.EF.Common
{
    public class TraceHelper
    {
        public static void TraceException(Exception excpetion, string commandText)
        {
            string error = string.Empty;
            error += "\r\n";
            error += "----Begin\r\n";
            error += $"异常:{excpetion}\r\n";
            error += $"执行语句:\r\n{commandText}\r\n";
            error += "----End\r\n";
            Trace.TraceError(error);
        }

        public static void TraceInformation(long excutedTime, string excuteMethod, string commandText)
        {
            string information = string.Empty;
            information += "\r\n";
            information += "----Begin\r\n";
            information += $"执行时间:{excutedTime} 毫秒\r\n";
            information += $"执行语句({excuteMethod}):\r\n{commandText}\r\n";
            information += "----End\r\n";
            Trace.TraceInformation(information);
        }
    }
}
