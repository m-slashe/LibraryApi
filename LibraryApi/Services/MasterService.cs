using LibraryApi.Models.Values;
using LibraryApi.Repositories.Interfaces;
using LibraryApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class MasterService : IMasterService
    {
        IMasterRepositorie _masterRepositorie;
        public MasterService(IMasterRepositorie masterRepositorie)
        {
            _masterRepositorie = masterRepositorie;
        }
        public async Task<ProdutoModel> ListarProduto()
        {
            return await _masterRepositorie.ListarProdutoAsync();
        }
    }
}
