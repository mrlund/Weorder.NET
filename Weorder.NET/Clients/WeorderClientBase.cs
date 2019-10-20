using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weorder.NET.Entities;
using Weorder.NET.Interfaces;
using Weorder.NET.Utilities;

namespace Weorder.NET.Clients
{
    public abstract class WeorderClientBase
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializer _jsonSerializer;
        private readonly JsonSerializerSettings _jsonSettings;
        protected readonly ILogger _logger;

        public WeorderClientBase(HttpClient httpClient, string accessToken = null, ILoggerFactory loggerFactory = null)
        {
            _httpClient = httpClient ?? throw new NullReferenceException(nameof(httpClient));
            _jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            _jsonSerializer = new JsonSerializer()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            if (loggerFactory != null)
            {
                _logger = loggerFactory.CreateLogger(this.GetType());
            }
            if (!string.IsNullOrEmpty(accessToken))
            {
                SetAccessToken(accessToken);
            }

        }

        protected void SetBaseUri(string baseUri)
        {
            _httpClient.BaseAddress = new Uri(baseUri);
        }
        public void SetAccessToken(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($":{accessToken}"))}");
        }
        public async Task<WeorderApiResponse<T>> MakeApiRequest<T>(string urlPath, RequestMethod method = RequestMethod.GET, object requestObject = null) where T : class
        {
            using (var req = await _httpClient.SendAsync(CreateRequest(urlPath, method, requestObject)))
            {
                if (req.IsSuccessStatusCode)
                {
                    return new WeorderApiResponse<T>(DeserializeAndUnwrap<T>(await req.Content.ReadAsStringAsync()));
                }

                return new WeorderApiResponse<T>(await HandleError(req));
            }

        }
        private HttpRequestMessage CreateRequest(string urlPath, RequestMethod method = RequestMethod.GET, object requestObject = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method.ToString()), urlPath);
            if (requestObject != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(requestObject, _jsonSettings), Encoding.UTF8, "application/json");
            }
            return request; 
        }
        private async Task<ErrorResponse> HandleError(HttpResponseMessage request)
        {
            var errorString = await request.Content.ReadAsStringAsync();
            if (_logger != null)
            {
                _logger.LogError(errorString);
            }
            if (string.IsNullOrEmpty(errorString))
            {
                return new ErrorResponse() { code = (int)request.StatusCode, message = request.ReasonPhrase };
            }
            var token = JToken.Parse(errorString);
            if (token is JArray)
            {
                return JsonConvert.DeserializeObject<List<ErrorResponse>>(errorString, _jsonSettings).FirstOrDefault();
            }
            else
            {
                return JsonConvert.DeserializeObject<ErrorResponse>(errorString, _jsonSettings);
            }

        }

        private T DeserializeAndUnwrap<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            //return JObject.Parse(json)[typeof(T).Name.ToLower()].ToObject<T>(_jsonSerializer);
            var jObject = JObject.Parse(json); 

            return jObject.ContainsKey("data") ? jObject["data"].ToObject<T>(_jsonSerializer) : jObject.ToObject<T>(_jsonSerializer);
        }
    }

}
