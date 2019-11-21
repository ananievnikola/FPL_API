using System.Net.Http;

namespace TopkaE.FPLDataDownloader.HttpRequests.Requesters
{
    public class RequesterFactory
    {
        public IRequester CreaterRequester(EBasicRequestType requesterType, HttpClient client)
        {
            switch (requesterType)
            {
                case EBasicRequestType.GeneralDataRequester:
                    return new GeneralDataRequester(client);
                default:
                    break;
            }
            return null;
        }
    }
}
