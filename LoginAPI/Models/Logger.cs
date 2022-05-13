using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        protected ILog monitoringLogger;

        private Logger()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
        }

        public static void Info(string message)
        {
            _instance.monitoringLogger.Info(message);
        }

        public static void Error(string message,Exception ex)
        {
            _instance.monitoringLogger.Error(message, ex);
        }

    }
}