using System;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Text;
using Microsoft.SqlServer.Server;

namespace Rico.EF.Common
{
    /// <summary>
    /// EF 日志输出
    /// </summary>
    public class EfIntercepterLogging : DbCommandInterceptor
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        #region Scalar
        public override void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }
        public override void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                TraceHelper.TraceException(interceptionContext.Exception, command.CommandText);
                //Trace.TraceError("Exception:{1} \r\n --> Error executing command: {0}", command.CommandText, interceptionContext.Exception);
            }
            else
            {
                TraceHelper.TraceInformation(_stopwatch.ElapsedMilliseconds, "ScalarExecuted", command.CommandText);
                //Trace.TraceInformation("\r\n执行时间:{0} 毫秒\r\n-->ScalarExecuted.Command:{1}\r\n", _stopwatch.ElapsedMilliseconds, command.CommandText);
            }
            base.ScalarExecuted(command, interceptionContext);
        }
        #endregion
        #region NonQuery

        public override void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }
        public override void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                TraceHelper.TraceException(interceptionContext.Exception, command.CommandText);
                //Trace.TraceError("Exception:{1} \r\n --> Error executing command:\r\n {0}", command.CommandText, interceptionContext.Exception);
            }
            else
            {
                TraceHelper.TraceInformation(_stopwatch.ElapsedMilliseconds, "NonQueryExecuted", command.CommandText);
                //Trace.TraceInformation("\r\n执行时间:{0} 毫秒\r\n-->NonQueryExecuted.Command:\r\n{1}", _stopwatch.ElapsedMilliseconds, command.CommandText);
            }
            base.NonQueryExecuted(command, interceptionContext);
        }
        #endregion
        #region NonQuery

        public override void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }
        public override void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                TraceHelper.TraceException(interceptionContext.Exception, command.CommandText);
                //Trace.TraceError("Exception:{1} \r\n --> Error executing command:\r\n {0}", command.CommandText, interceptionContext.Exception);
            }
            else
            {
                TraceHelper.TraceInformation(_stopwatch.ElapsedMilliseconds, "ReaderExecuted", command.CommandText);
                //Trace.TraceInformation("\r\n执行时间:{0} 毫秒 \r\n -->ReaderExecuted.Command:\r\n{1}", _stopwatch.ElapsedMilliseconds, command.CommandText);
            }
            base.ReaderExecuted(command, interceptionContext);
        }
        #endregion
    }

    public class TraceHelper
    {
        public static void TraceException(Exception excpetion,string commandText)
        {
            string error = string.Empty;
            error += "\r\n";
            error += "----Begin\r\n";
            error += $"异常:{excpetion}\r\n";
            error += $"执行语句:\r\n{commandText}\r\n";
            error += "----End\r\n";
            Trace.TraceError(error);
        }

        public static void TraceInformation(long excutedTime,string excuteMethod, string commandText)
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
