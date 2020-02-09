using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryApi.Models.Values;

namespace LibraryApi.Repositories.Interfaces
{
    public interface IMasterRepositorie
    {
        Task<ProdutoModel> ListarProdutoAsync();
    }
}
