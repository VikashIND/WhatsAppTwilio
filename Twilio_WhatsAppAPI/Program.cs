using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Converters;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Api.V2010.Account.Message;

namespace Twilio_WhatsAppAPI
{
    class Program
    {
        static void Main(string[] args)
        {
                  var uris = new List<Uri>();
            uris.Add(new Uri("URL"));

            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "";
            const string authToken = "";
            

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello there! Please find your receipt",
                from: new Twilio.Types.PhoneNumber("whatsapp:+Number"),
                to: new Twilio.Types.PhoneNumber("whatsapp:+Number"), 
                mediaUrl: Promoter.ListOfOne(new Uri("URL"))
               
            );
            Console.WriteLine(message);
            Console.WriteLine(message.Sid);
            Console.ReadKey();
        }
    }
    
}
