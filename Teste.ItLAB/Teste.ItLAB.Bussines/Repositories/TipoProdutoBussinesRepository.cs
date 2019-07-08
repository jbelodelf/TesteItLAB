using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Bussines.Interface;
using Teste.ItLAB.Model.Dtos;
using Teste.ItLAB.Model.Interfaces;

namespace Teste.ItLAB.Bussines.Repositories
{
    public class TipoProdutoBussinesRepository : ITipoProdutoBussines
    {
        private readonly ITipoProdutoRepository _tipoProdutoRepository;
        private readonly IMapper _mapper;

        public TipoProdutoBussinesRepository(ITipoProdutoRepository tipoProdutoRepository, IMapper mapper)
        {
            _tipoProdutoRepository = tipoProdutoRepository;
            _mapper = mapper;
        }

        public List<TipoProdutoDTO> GetTiposProdutos()
        {
            var tiposProdutosEntity = _tipoProdutoRepository.GetTiposProdutos();
            var tiposProdutosDTO = _mapper.Map<List<TipoProdutoDTO>>(tiposProdutosEntity);
            return tiposProdutosDTO;
        }
    }
}
