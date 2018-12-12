using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Newtonsoft.Json;
namespace WhatsAppLibrary
{
    public  class SendWhatsAppMessage
    {
        public static async Task<string> SendMessageAsync(string mobileNO, string body, List<Uri> reportUrl)
        {
            MessageResource result;

            using (RestClient client = new RestClient())
            {
                result = await client.SendMessage(Credentials.TwilioPhoneNumber, mobileNO, body, reportUrl);
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}
