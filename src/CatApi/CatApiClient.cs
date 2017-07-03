using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;

namespace CatApi
{
    public class CatApiClient : ICatApiClient
    {
        private HttpClient _client;
        private readonly ILogger<CatApiClient> _logger;

        public CatApiClient(ILogger<CatApiClient> logger)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://thecatapi.com/api/");
            _logger = logger;
        }

        public async Task<CatApiResponse> List(int max)
        {
            var sw = new Stopwatch();
            sw.Start();
            var httpResponse = await _client.GetAsync($"images/get?format=xml&results_per_page={WebUtility.UrlEncode(max.ToString())}");
            sw.Stop();

            var responseString = await httpResponse.Content.ReadAsStringAsync();
            
            _logger.LogDebug("{xml}", responseString);

            return new CatApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                TimeTaken = sw.Elapsed,
                Response = Deserialize<Response>(responseString),
            };
        }

        public static T Deserialize<T>(string s) where T : class
        {
            var deserializer = new XmlSerializer(typeof(T));
            return deserializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(s))) as T;
        }
    }

    public class CatApiResponse
    {
        public TimeSpan TimeTaken { get; set; }
        public int StatusCode { get; set; }
        public Response Response { get; set; }
    }
}