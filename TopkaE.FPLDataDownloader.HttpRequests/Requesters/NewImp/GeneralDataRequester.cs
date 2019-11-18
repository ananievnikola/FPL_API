using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters.NewImp
{
    public class GeneralDataRequester : Requester//: HttpClientWrapperBase
    {
        public GeneralDataRequester() : base()
        {
        }
        public override async Task<string> ExecuteRequest()
        {
            string responseBody = null;
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("https://fantasy.premierleague.com/api/bootstrap-static/");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                //Refactor
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return responseBody;
        }
    }
}
