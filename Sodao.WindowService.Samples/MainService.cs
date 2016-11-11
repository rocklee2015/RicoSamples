using log4net.Config;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Sodao.WindowService.Samples.JobService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
[assembly: XmlConfigurator(ConfigFile = @"config\log4net.config", Watch = false)]
namespace Sodao.WindowService.Samples
{
    public class MainService : ServiceBase
    {
        private System.ComponentModel.IContainer components = null;
        static private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MainService));
        IScheduler sched = null;
        /// <summary>
        /// new
        /// </summary>
        public MainService()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = ConfigurationManager.AppSettings["ServiceName"];

            AppDomain.CurrentDomain.UnhandledException += (obj, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                if (ex != null)
                    logger.Error(ex.Message, ex);
            };
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += (obj, e) =>
            {
                e.SetObserved();
                e.Exception.Flatten().Handle(c =>
                {
                    logger.Error(c.Message, c);
                    return true;
                });
            };
        }
        protected override void OnStart(string[] args)
        {
            logger.Info("CRM服务开始！");
            ISchedulerFactory sf = new StdSchedulerFactory();
            sched = sf.GetScheduler();

            var invoiceJob = new JobDetailImpl("invoiceJob", "group4", typeof(InvoiceJob));
            //1分钟一次
            var invoiceTrigger = new SimpleTriggerImpl("trigger3", "group4", -1, new TimeSpan(0, 1, 0));
            sched.ScheduleJob(invoiceJob, invoiceTrigger);
            sched.Start();
            logger.Info("CRM服务结束！");

        }
    }
}
