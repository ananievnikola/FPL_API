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
        private int MyProperty { get; set; }
        public HttpClientWrapperBase()
        {
            this.SetHttpClient();
        }

        //public bool HasAuthCookie()
        //{
        //    CookieContainerSingleton s = CookieContainerSingleton.GetInstance;
        //    CookieContainer cc = s.GetCookieContainer();
        //    Uri uri = new Uri("https://users.premierleague.com/accounts/login/");
        //    IEnumerable<Cookie> responseCookies = cc.GetCookies(uri).Cast<Cookie>();
        //    string authCookie = responseCookies.FirstOrDefault(c => c.Name == "csrftoken").Value;
        //    if (!string.IsNullOrEmpty(authCookie))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private void SetHttpClient()
        {            
            HttpClientHandler handler = new HttpClientHandler();
            CookieContainerSingleton s = CookieContainerSingleton.GetInstance;
            handler.CookieContainer = s.GetCookieContainer();
            this.HttpClient = new HttpClient(handler);
        }
    }
}

