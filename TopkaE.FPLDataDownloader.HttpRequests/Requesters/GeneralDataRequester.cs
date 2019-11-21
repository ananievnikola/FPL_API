using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public class GeneralDataRequester : RequesterBase, IRequester//: HttpClientWrapperBase
    {
        protected override HttpClient _client { get; set; }
        internal GeneralDataRequester(HttpClient client) : base(client)
        {
        }
        public override async Task<string> ExecuteRequest()
        {
            string responseBody = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://fantasy.premierleague.com/api/bootstrap-static/");
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
