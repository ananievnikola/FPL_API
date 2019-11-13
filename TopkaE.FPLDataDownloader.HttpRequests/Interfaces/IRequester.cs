using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.HttpRequests.Interfaces
{
    public interface IRequester
    {
        Task<string> ExecuteRequest();
    }
}
