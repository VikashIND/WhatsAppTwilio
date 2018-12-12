using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Topshelf;
using WhatsAppLibrary;

namespace WhatsAppService
{
    public class WhatsAppMessageService : ServiceControl
    {
        readonly Timer _timer;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WhatsAppMessageService()
        {
            _timer = new Timer(UtilHelper.GetRunningFrequency()) { AutoReset = true };
            _timer.Elapsed += timer_Elapsed;
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            Console.WriteLine("It is {0} and all is well", DateTime.Now);
            log.Info(string.Format("It is {0} and all is well ", DateTime.Now));
             SendMessage();
        }
        public bool Start(HostControl hostControl)
        {
           
            log.Info(string.Format("It is {0} and all is well, Service Strated!", DateTime.Now));
            _timer.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
           
            log.Info(string.Format("It is {0} and all is well, Service Stoped! ", DateTime.Now));
            _timer.Stop();
            return true;
        }

        public static void SendMessage()
        {
            var mobileNo = "whatsapp:+Number";
            var url = new Uri("URL");
            var body = "Hello There! Please find your receipt.";
            List<Uri> uriList = new List<Uri>();
            uriList.Add(url);
            try
            {
                
                 log.Info(SendWhatsAppMessage.SendMessageAsync(mobileNo, body, uriList).GetAwaiter().GetResult());


            }
            catch (Exception ex)
            {

                log.Error(ex);
            }
        }
    }
}
