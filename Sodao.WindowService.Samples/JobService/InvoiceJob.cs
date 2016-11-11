using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.WindowService.Samples.JobService
{
    public class InvoiceJob : IJob
    {
        static private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(InvoiceJob));
        public void Execute(IJobExecutionContext context)
        {
            logger.Info("执行任务！");
        }
    }
}
