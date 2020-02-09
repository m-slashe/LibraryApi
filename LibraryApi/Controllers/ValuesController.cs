using LibraryApi.Models.Values;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        IConfiguration _configuration;
        IMasterService _masterService;
        public ValuesController(IConfiguration configuration, IMasterService masterService)
        {
            _configuration = configuration;
            _masterService = masterService;
        }

        [HttpGet]
        public string Lista()
        {
            return "Funcionou";
        }

        [Authorize]
        [HttpGet]
        public object TesteAuth()
        {
            return HttpContext.Items["UserInfo"];
        }

        [HttpGet("listaProduto")]
        public async Task<ProdutoModel> ListaProduto()
        {
            return await _masterService.ListarProduto();
        }

        [HttpGet("config")]
        public object ListaConfig()
        {
            return _configuration["Teste"];
        }        
    }
}
