using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters.NewImp
{
    public class BasicRequesterFactory : RequesterFactory
    {
        public override Requester CreaterRequester(EBasicRequestType type)
        {
            switch (type)
            {
                case EBasicRequestType.GeneralDataRequester:
                    return new GeneralDataRequester();
                default:
                    return null;
            }
        }
    }
}
