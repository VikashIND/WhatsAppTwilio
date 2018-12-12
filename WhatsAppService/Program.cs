using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WhatsAppService
{
    class Program
    {
        static void Main(string[] args)
        {
            UtilHelper.ChangeFilePath("MyRollingFileAppender", UtilHelper.LogFilePath());          
            HostFactory.Run(host => {
                host.SetServiceName("WhatsAppService");
                host.SetDisplayName("Whats App Service");
                host.SetDescription("The WhatsApp client Service is allows to send the WhatsApp messages to the registered users.");
                host.StartManually();
                host.RunAsLocalService();
                host.Service<WhatsAppMessageService>();
            });
        }
    }
}
