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
            }
            else
            {
                TraceHelper.TraceInformation(_stopwatch.ElapsedMilliseconds, "ScalarExecuted", command.CommandText);
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
            }
            else
            {
                TraceHelper.TraceInformation(_stopwatch.ElapsedMilliseconds, "NonQueryExecuted", command.CommandText);
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
            }
            else
            {
                TraceHelper.TraceInformation(_stopwatch.ElapsedMilliseconds, "ReaderExecuted", command.CommandText);
            }
            base.ReaderExecuted(command, interceptionContext);
        }
        #endregion
    }

  
}
