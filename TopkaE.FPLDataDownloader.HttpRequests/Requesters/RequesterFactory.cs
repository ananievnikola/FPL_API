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
                case EBasicRequestType.PlayerSummaryRequester:
                    return new PlayerSummaryRequester(client);
                default:
                    break;
            }
            return null;
        }
    }
}
