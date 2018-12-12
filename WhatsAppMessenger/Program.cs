using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Converters;
using Twilio.Rest.Api.V2010.Account;
using WhatsAppMessenger.Twilio;
using Newtonsoft.Json;
using log4net.Repository;

namespace WhatsAppMessenger
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            string path = String.Format("{0}{1}{2}{3}{4}", "Log_", DateTime.Now.Month.ToString()
                                     , DateTime.Now.Day.ToString()
                                     , DateTime.Now.Year.ToString(), ".log");

          //  ChangeFilePath("MyRollingFileAppender", path);


            //XmlConfigurator.Configure();
            // log.Debug("Debug message");
            //log.Info("Info message");
            // log.Warn("Warning message");
            // log.Error("Error message");
            // log.Fatal("Fatal message");
            var mobileNo = "whatsapp:+Number";
            var url = new Uri("URL");
            var body = "Hello There! Please find your receipt.";
            MessageResource result;
            try
            {
                //throw new Exception();
               
                result = SendWhatsAppMessagerAsync(mobileNo,body, Promoter.ListOfOne(url)).GetAwaiter().GetResult();
                log.Info(JsonConvert.SerializeObject(result));
                
            }
            catch (Exception ex) {
               
                log.Error(ex);
            }
          
        }

        private static async Task<MessageResource> SendWhatsAppMessagerAsync(string mobileNO, string body, List<Uri> reportUrl)
        {
            using (RestClient client = new RestClient())
            {


                var result = await client.SendMessage(Credentials.TwilioPhoneNumber, mobileNO, body, reportUrl);


                return result;
            }
        }
        public static void ChangeFilePath(string appenderName, string newFilename)
        {
            ILoggerRepository repository =LogManager.GetRepository();
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
