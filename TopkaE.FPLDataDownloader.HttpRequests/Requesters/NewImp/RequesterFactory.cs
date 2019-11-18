using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters.NewImp
{
    public abstract class RequesterFactory
    {
        public abstract Requester CreaterRequester(EBasicRequestType requesterType);
    }
}
