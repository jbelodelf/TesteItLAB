using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Model.Dtos;

namespace Teste.ItLAB.Bussines.Interface
{
    public interface IProdutoBussines
    {
        List<ProdutoDTO> GetProdutos();
        ProdutoDTO GetProduto(int Id);
        ProdutoDTO GetProduto(string Nome);
        bool AddProduto(ProdutoDTO produto);
        bool UpdateProduto(ProdutoDTO produto);
        bool DeleteProduto(int Id);
    }
}
