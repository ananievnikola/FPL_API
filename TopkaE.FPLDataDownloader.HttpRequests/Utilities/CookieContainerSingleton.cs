using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TopkaE.FPLDataDownloader.HttpRequests.Utilities
{
    //I implement this as singleton instead of HttpClient for that reason: 
    //http://byterot.blogspot.com/2016/07/singleton-httpclient-dns.html
    public sealed class CookieContainerSingleton
    {
        private CookieContainerSingleton()
        {
            Console.WriteLine("Private constructor");
            _cookieContainer = new CookieContainer();
        }
        private static CookieContainerSingleton instance = null;
        private static readonly object Instancelock = new object();
        private static CookieContainer _cookieContainer { get; set; }
        public static CookieContainerSingleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new CookieContainerSingleton();
                        }
                    }
                }
                return instance;
            }
        }

        public CookieContainer GetCookieContainer()
        {
            return _cookieContainer;
        }

        public bool HasAuthCookie()
        {
            //CookieContainerSingleton s = CookieContainerSingleton.GetInstance;
            //CookieContainer cc = s.GetCookieContainer();
            Uri uri = new Uri("https://users.premierleague.com/accounts/login/");
            IEnumerable<Cookie> responseCookies = _cookieContainer.GetCookies(uri).Cast<Cookie>();
            if (responseCookies == null)
            {
                return false;
            }
            string authCookie = responseCookies.FirstOrDefault(c => c.Name == "csrftoken")?.Value;
            if (!string.IsNullOrEmpty(authCookie))
            {
                return true;
            }
            return false;
        }
    }
}
