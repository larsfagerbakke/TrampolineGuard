using System;
using System.Collections.Generic;
using System.Text;

namespace TrampolineGuard.Shared.Models
{
    public abstract class OnlineService
    {
        protected string authId { get; set; }
        protected string authToken { get; set; }
        protected string serviceSource { get; set; }

        private OnlineService() { }

        public OnlineService(string authId, string authToken, string serviceSource)
        {
            this.authId = authId;
            this.authToken = authToken;
            this.serviceSource = serviceSource;
        }
    }
}
