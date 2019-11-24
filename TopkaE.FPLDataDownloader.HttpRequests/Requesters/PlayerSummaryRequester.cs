using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public class PlayerSummaryRequester : RequesterBase, IRequester, IParameterizedRequester
    {
        protected override HttpClient _client { get; set; }
        private int id = 0;
        internal PlayerSummaryRequester(HttpClient client) : base(client)
        {
        }
        public async Task<string> ExecuteRequest()
        {
            string responseBody = null;
            if (id == 0)
            {
                throw new Exception("Call SetUpParams method first");
            }
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://fantasy.premierleague.com/api/element-summary/" + id + "/");
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

        /// <summary>
        /// This method is waiting for a parameter named id to be passed with the dictionary.
        /// Any other parameter passed with the dictionary will be ignored
        /// </summary>
        /// <param name="parameters"></param>
        public void SetUpParams(Dictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                throw new Exception("Parameters are required");
            }
            if (!parameters.ContainsKey("id") || parameters["id"] == null)
            {
                throw new Exception("Parameter id is required");
            }
            this.id = int.Parse(parameters["id"].ToString());
        }
    }
}
