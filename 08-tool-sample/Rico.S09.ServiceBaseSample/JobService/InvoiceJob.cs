using Quartz;

namespace Rico.S09.ServiceBaseSample.JobService
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
