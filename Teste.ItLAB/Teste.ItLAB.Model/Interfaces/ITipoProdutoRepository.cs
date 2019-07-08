using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Model.Entities;

namespace Teste.ItLAB.Model.Interfaces
{
    public interface ITipoProdutoRepository
    {
        List<TipoProdutoEntity> GetTiposProdutos();
    }
}
