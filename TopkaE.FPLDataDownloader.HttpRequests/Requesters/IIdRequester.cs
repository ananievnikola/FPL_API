using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public interface IParameterizedRequester
    {
        //Task<string> ExecuteRequest(int id);
        /// <summary>
        /// Every requester that needs parameters to execute its ExecuteRequest method
        /// needs to implement this method as it needs. It is designed to set some class members
        /// values that will be used in the implementation of ExecuteRequest method
        /// </summary>
        /// <param name="parameters"></param>
        void SetUpParams(Dictionary<string, object> parameters);
    }
}
