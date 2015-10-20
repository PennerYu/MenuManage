using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.ServicesFramework.QuartzNet
{
    using log4net;
    using Quartz;
    using Quartz.Xml;
    using Quartz.Impl;
    using Penner.ServicesFramework.Utils;

    public class QuartzFactory : IServiceFactory
    {
        public object ServiceInit()
        {
            ILog log = ServiceUtils.GetLogger("quartz.job.log");
            log.Info("------- Initializing ----------------------");
            try
            {
                ISchedulerFactory sf = new StdSchedulerFactory();
                IScheduler sched = sf.GetScheduler();
                JobSchedulingDataProcessor processor = new JobSchedulingDataProcessor(true, true);
                processor.ProcessFileAndScheduleJobs(string.Format("{0}/Config/Job.xml", AppDomain.CurrentDomain.BaseDirectory), sched, true);
                sched.Start();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return null;
        }
    }
}
