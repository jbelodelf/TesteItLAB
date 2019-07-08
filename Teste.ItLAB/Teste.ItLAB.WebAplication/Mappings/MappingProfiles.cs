using AutoMapper;
using Teste.ItLAB.Model.Dtos;
using Teste.ItLAB.WebAplication.Models;

namespace Teste.ItLAB.WebAplication.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProdutoDTO, ProdutoViewModel>().ReverseMap();
            CreateMap<TipoProdutoDTO, TipoProdutoViewModel>().ReverseMap();
        }
    }
}
