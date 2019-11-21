using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public interface IRequester
    {
        Task<string> ExecuteRequest();
    }
}
