using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public abstract class RequesterBase : IRequester
    {
        protected virtual HttpClient _client { get; set; }
        internal RequesterBase(HttpClient client)
        {
            _client = client;
        }

        public virtual Task<string> ExecuteRequest()
        {
            throw new NotImplementedException();
        }
    }
}
