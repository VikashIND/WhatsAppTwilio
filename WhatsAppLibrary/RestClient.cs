using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WhatsAppLibrary
{
    public class RestClient : IRestClient, IDisposable
    {
        private readonly ITwilioRestClient _client;

        public RestClient()
        {
            _client = new TwilioRestClient(
                Credentials.TwilioAccountSid,
                Credentials.TwilioAuthToken
            );
        }

        public RestClient(ITwilioRestClient client)
        {
            _client = client;
        }

        public async Task<MessageResource> SendMessage(string from, string to, string body, List<Uri> mediaUrl)
        {
            var toPhoneNumber = new PhoneNumber(to);
            return await MessageResource.CreateAsync(
                toPhoneNumber,
                from: new PhoneNumber(from),
                body: body,
                mediaUrl: mediaUrl,
                client: _client);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RestClient() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
