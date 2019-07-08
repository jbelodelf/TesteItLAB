using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Model.Dtos;
using Teste.ItLAB.Model.Entities;

namespace Teste.ItLAB.Bussines.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProdutoEntity, ProdutoDTO>().ReverseMap();
            CreateMap<TipoProdutoEntity, TipoProdutoDTO>().ReverseMap();
        }
    }
}
