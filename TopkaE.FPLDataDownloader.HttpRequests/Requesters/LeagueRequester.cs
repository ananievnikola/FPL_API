using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.HttpRequests.Base;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public class LeagueRequester : HttpClientWrapperBase
    {
        public LeagueRequester() : base()
        {

        }
        public async Task<string> ExecuteRequest(int leagueId, int page)
        {
            string responseBody = string.Empty;
            StringBuilder sb = new StringBuilder();
            var result = await
                HttpClient.GetAsync("https://fantasy.premierleague.com/api/leagues-classic/" + leagueId + "/standings/?page_standings=" + page);
            result.EnsureSuccessStatusCode();
            if (page == 6)
            {
                var a = 1;
            }
            //sb.Append(await result.Content.ReadAsStringAsync());

            responseBody = await result.Content.ReadAsStringAsync();
            return responseBody;
        }

    }
}
