using Plivo;
using System;
using System.Collections.Generic;
using System.Text;
using TrampolineGuard.Shared.Models;

namespace TrampolineGuard.Shared
{
    public interface INotify
    {
        void SendMessage(string recipient, string message);
    }   

    /// <summary>
    /// Simple implementation of Plivo (www.plivo.com)
    /// </summary>
    public class SMSNotify : OnlineService, INotify
    {
        private PlivoApi api;

        /// <summary>
        /// Plivo implementation constructor
        /// </summary>
        /// <param name="authId">Plivo auth id</param>
        /// <param name="authToken">Plivo auth token</param>
        /// <param name="serviceSource">Service name that the recipient will see</param>
        public SMSNotify(string authId, string authToken, string serviceSource) : base(authId, authToken, serviceSource)
        {
            api = new PlivoApi(authId, authToken);
        }

        /// <summary>
        /// Sends SMS message
        /// </summary>
        /// <param name="recipient">Recipient number, E.164 format</param>
        /// <param name="message">Message to send</param>
        public void SendMessage(string recipient, string message)
        {
            // TODO: Should really check what Plivo returns...
            var response = api.Message.Create(
                src: this.serviceSource,
                dst: new List<String> { recipient },
                text: message
                );
        }
    }
}
