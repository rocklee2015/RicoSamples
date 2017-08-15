using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Topshelf;
using System.Timers;

namespace Rico.S09.TopshelfV4
{
    public class TownCrier : ServiceControl
    {
        private Timer _timer = null;
        readonly ILog _log = LogManager.GetLogger(typeof(TownCrier));
        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => _log.Info(DateTime.Now);

        }
        public bool Start(HostControl hostControl)
        {
            _log.Info("服务开始");
            _timer.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _log.Info("---服务停止！");
            _timer.Stop();
            return true;
        }
    }

}
