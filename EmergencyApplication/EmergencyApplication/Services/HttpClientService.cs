using EmergencyApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyApplication.Services
{
    public class HttpClientService<T> 
    {
        private HttpClient _client;
        public HttpClient Client
        { get
            {
                if (_client == null)
                {
                    var httpClientHandler = new HttpClientHandler();
                    _client = new HttpClient();
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    _client = new HttpClient(httpClientHandler);
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                }
                return _client;
            } 
        }
        public async Task<HttpResponseModel> PostAsync(T t, string url)
        {
            var json = JsonConvert.SerializeObject(t); 
            var request = new HttpRequestMessage(HttpMethod.Post, AppSettings.BaseUrl + url)
            {
                Content = new StringContent(
                         JsonConvert.SerializeObject(t),
                         Encoding.UTF8,
                         "application/json"
                     )
            };
            _client = null;
            var response = await Client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HttpResponseModel>(content);
            return result;
        }
        public async Task<HttpResponseModel> GetAsync(string url)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(AppSettings.BaseUrl + url);
            _client = null;
            var response = await Client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HttpResponseModel>(content);
            return result;
        }
    }
}
