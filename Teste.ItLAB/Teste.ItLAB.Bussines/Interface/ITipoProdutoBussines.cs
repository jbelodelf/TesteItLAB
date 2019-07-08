using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Model.Dtos;
using Teste.ItLAB.Model.Entities;

namespace Teste.ItLAB.Bussines.Interface
{
    public interface ITipoProdutoBussines
    {
        List<TipoProdutoDTO> GetTiposProdutos();
    }
}
