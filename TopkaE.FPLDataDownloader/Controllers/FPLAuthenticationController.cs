using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopkaE.FPLDataDownloader.HttpRequests.Requesters;

namespace TopkaE.FPLDataDownloader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FPLAuthenticationController : ControllerBase
    {
        [Route("")]
        [Route("Get")]
        public async Task<bool> Authenticate(string user, string pass)
        {
            bool result = false;
            AuthenticationRequester r = new AuthenticationRequester(user, pass);
            result = await r.ExecuteRequest();
            return result;
        }
    }
}