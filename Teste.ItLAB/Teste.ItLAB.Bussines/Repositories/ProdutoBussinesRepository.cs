using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Teste.ItLAB.Bussines.Interface;
using Teste.ItLAB.Model.Dtos;
using Teste.ItLAB.Model.Entities;
using Teste.ItLAB.Model.Interfaces;

namespace Teste.ItLAB.Bussines.Repositories
{
    public class ProdutoBussinesRepository : IProdutoBussines
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoBussinesRepository(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public bool AddProduto(ProdutoDTO produto)
        {
            var produtosEntity = _mapper.Map<ProdutoEntity>(produto);
            _produtoRepository.AddProduto(produtosEntity);
            return true;
        }

        public bool DeleteProduto(int Id)
        {
            _produtoRepository.DeleteProduto(Id);
            return true;
        }

        public ProdutoDTO GetProduto(int Id)
        {
            var produtoEntity = _produtoRepository.GetProduto(Id);
            var produtosDTO = _mapper.Map<ProdutoDTO>(produtoEntity);
            return produtosDTO;
        }

        public ProdutoDTO GetProduto(string Nome)
        {
            var produtoEntity = _produtoRepository.GetProduto(Nome);
            var produtosDTO = _mapper.Map<ProdutoDTO>(produtoEntity);
            return produtosDTO;
        }

        public List<ProdutoDTO> GetProdutos()
        {
            var produtosEntity = _produtoRepository.GetProdutos().ToList();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtosEntity);
            return produtosDTO;
        }

        public bool UpdateProduto(ProdutoDTO produto)
        {
            var produtosEntity = _mapper.Map<ProdutoEntity>(produto);
            _produtoRepository.UpdateProduto(produtosEntity);
            return true;
        }
    }
}
