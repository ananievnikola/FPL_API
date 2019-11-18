using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.HttpRequests.Interfaces;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters.NewImp
{
    public class Requester : IRequester
    {
        protected HttpClient HttpClient { get; private set; }
        public Requester()
        {
            this.HttpClient = new HttpClient();
        }

        public virtual Task<string> ExecuteRequest()
        {
            throw new NotImplementedException("Implement in the subclass!");
        }
    }
}
