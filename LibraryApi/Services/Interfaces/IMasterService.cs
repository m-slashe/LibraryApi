using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryApi.Models.Values;

namespace LibraryApi.Services.Interfaces
{
    public interface IMasterService
    {
        Task<ProdutoModel> ListarProduto();
    }
}
