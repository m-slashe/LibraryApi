using LibraryApi.Models.Values;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController: ControllerBase
    {
        [HttpGet]
        public string Lista()
        {
            return "Funcionou";
        }

        //[Authorize]
        [HttpGet("listaProduto")]
        public async Task<ProdutoModel> ListaProduto()
        {
            //return HttpContext.Items["UserInfo"];
            return await Get<ProdutoModel>("/api/values/listaProduto");
        }

        public async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:5001") })
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
