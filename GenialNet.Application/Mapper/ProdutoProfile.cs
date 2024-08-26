using AutoMapper;
using GenialNet.Application.Produtos.Commands.CadastrarProduto;
using GenialNet.Domain.Entities;

namespace GenialNet.Application.Mapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CadastrarProdutoRequest, Produto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
          
        }
    }   
}
