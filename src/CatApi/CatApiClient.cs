using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CatApi
{
    public class CatApiClient
    {
        private HttpClient _client;

        public CatApiClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://thecatapi.com/api/");
        }

        public async Task<CatApiResponse> List(int max)
        {
            var sw = new Stopwatch();
            sw.Start();
            var httpResponse = await _client.GetAsync($"images/get?format=xml&results_per_page={WebUtility.UrlEncode(max.ToString())}");
            sw.Stop();

            return new CatApiResponse
            {
                StatusCode = (int)httpResponse.StatusCode,
                TimeTaken = sw.Elapsed,
                Response = Deserialize<Response>(await httpResponse.Content.ReadAsStreamAsync()),
            };
        }

        private T Deserialize<T>(Stream stream) where T : class
        {
            var deserializer = new XmlSerializer(typeof(T));
            return deserializer.Deserialize(stream) as T;
        }
    }

    public class CatApiResponse
    {
        public TimeSpan TimeTaken { get; set; }
        public int StatusCode { get; set; }
        public Response Response { get; set; }
    }
}