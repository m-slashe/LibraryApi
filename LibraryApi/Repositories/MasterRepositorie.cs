using LibraryApi.Models.Values;
using LibraryApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryApi.Utils.Http;

namespace LibraryApi.Repositories
{
    public class MasterRepositorie: IMasterRepositorie
    {
        private const string BASE_URL = "https://localhost:5001";
        public async Task<ProdutoModel> ListarProdutoAsync() => await Get<ProdutoModel>("/api/values/listaProduto");


        private async Task<T> Get<T>(string url) => await HttpUtils.Get<T>(BASE_URL, url);
    }
}
