using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Model.Entities;

namespace Teste.ItLAB.Model.Interfaces
{
    public interface IProdutoRepository
    {
        List<ProdutoEntity> GetProdutos();
        ProdutoEntity GetProduto(int Id);
        ProdutoEntity GetProduto(string Nome);
        bool AddProduto(ProdutoEntity produto);
        bool UpdateProduto(ProdutoEntity produto);
        bool DeleteProduto(int Id);
    }
}
