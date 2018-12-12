using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;
using WhatsAppLibrary;

namespace WhatsAppService
{
    public class TownCrier
    {
        readonly Timer _timer;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TownCrier()
        {
            _timer = new Timer(UtilHelper.GetRunningFrequency()) { AutoReset = true };
            _timer.Elapsed += timer_Elapsed;
            //   _timer.Elapsed += (sender, eventArgs) =>Console.WriteLine("It is {0} and all is well", DateTime.Now);

        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        { 
           
            Console.WriteLine("It is {0} and all is well", DateTime.Now);
            log.Info(string.Format( "It is {0} and all is well ",DateTime.Now));
           // SendMessage();
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }

        public static void SendMessage()
        {
            var mobileNo = "whatsapp:+919716243141";
            var url = new Uri("url");
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
