using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using TopkaE.FPLDataDownloader.HttpRequests.Interfaces;
using TopkaE.FPLDataDownloader.HttpRequests.Utilities;

namespace TopkaE.FPLDataDownloader.HttpRequests.Base
{
    public class HttpClientWrapperBase
    {
        protected HttpClient HttpClient { get; private set; }
        //private int MyProperty { get; set; }
        public HttpClientWrapperBase()
        {
            this.SetHttpClient();
        }

        private void SetHttpClient()
        {            
            HttpClientHandler handler = new HttpClientHandler();
            CookieContainerSingleton s = CookieContainerSingleton.GetInstance;
            handler.CookieContainer = s.GetCookieContainer();
            this.HttpClient = new HttpClient(handler);
        }
    }
}

