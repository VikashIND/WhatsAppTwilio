using System;
using System.Configuration;
using log4net.Repository;
using log4net;

namespace WhatsAppService
{
    public class UtilHelper
    {
       public static double GetRunningFrequency()
        {
            return Convert.ToDouble(ConfigurationManager.AppSettings["RunningFrequency"]);
        }
       
        public static string LogFilePath()
        {
            return String.Format("{0}{1}{2}{3}{4}"
                ,   "Log_"
                ,   DateTime.Now.Month.ToString()
                ,   DateTime.Now.Day.ToString()
                ,   DateTime.Now.Year.ToString(), ".log");
        }
        public static void ChangeFilePath(string appenderName, string newFilename)
        {
            ILoggerRepository repository = LogManager.GetRepository();
            foreach (log4net.Appender.IAppender appender in repository.GetAppenders())
            {
                if (appender.Name.CompareTo(appenderName) == 0 && appender is log4net.Appender.FileAppender)
                {
                    log4net.Appender.FileAppender fileAppender = (log4net.Appender.FileAppender)appender;
                    fileAppender.File = System.IO.Path.Combine(fileAppender.File, newFilename);
                    fileAppender.ActivateOptions();
                }
            }
        }
    }
}
