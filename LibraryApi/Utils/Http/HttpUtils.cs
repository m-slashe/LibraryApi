using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Utils.Http
{
    public class HttpUtils
    {
        public static async Task<T> Get<T>(string baseUrl, string url)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url);

                if (response != null && response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<T>(jsonString);

                    return resultado;
                }
            }

            return default(T);
        }
    }
}
