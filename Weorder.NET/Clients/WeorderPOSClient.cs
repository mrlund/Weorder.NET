using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Weorder.NET.Utilities;

namespace Weorder.NET.Clients
{
    public class WeorderPOSClient : WeorderClientBase
    {
        public WeorderPOSClient(string baseUri,
                                HttpClient httpClient,
                                string accessToken = null,
                                ILoggerFactory loggerFactory = null,
                                TargetEnvironment environment = TargetEnvironment.STAGING) : base(httpClient, accessToken, loggerFactory)
        {
            SetBaseUri(environment == TargetEnvironment.PRODUCTION ? "https://poshub.weorder.com" : environment == TargetEnvironment.STAGING ? "https://staging-poshub.snappo.com" : "http://82.196.1.109");
        }
    }
}
