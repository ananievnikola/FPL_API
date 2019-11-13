using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.HttpRequests.Base;
using TopkaE.FPLDataDownloader.HttpRequests.Interfaces;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public class AuthenticationRequester : HttpClientWrapperBase
    {
        private FormUrlEncodedContent content;
        public AuthenticationRequester(string pass, string login) : base()
        {
            SetUpAuthParams(pass, login);
        }

        

        public async Task<bool> ExecuteRequest()
        {
            bool success = false;
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("password", "xxx"),//temp, dont wanna push my real pass
                new KeyValuePair<string, string>("login", "xxx@gmail.com"),
                new KeyValuePair<string, string>("redirect_uri", "https://fantasy.premierleague.com/a/login"),
                new KeyValuePair<string, string>("app", "plfpl-web"),
            });

            HttpResponseMessage response = await HttpClient.PostAsync("https://users.premierleague.com/accounts/login/", stringContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                success = true;
            }
            return success;
            //

            //var result = await
            //    HttpClient.GetAsync("https://fantasy.premierleague.com/api/leagues-classic/" + leagueId + "/standings/?page_new_entries=1&page_standings=1");
            //result.EnsureSuccessStatusCode();
            //responseBody = await result.Content.ReadAsStringAsync();
        }

        private void SetUpAuthParams(string pass, string login)
        {
            content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("password", pass),//temp, dont wanna push my real pass
                new KeyValuePair<string, string>("login", login),
                new KeyValuePair<string, string>("redirect_uri", "https://fantasy.premierleague.com/a/login"),
                new KeyValuePair<string, string>("app", "plfpl-web"),
            });
        }
    }
}
