using AutoMapper;
using GenialNet.Application.Fornecedores.Commands.AtualizarFornecedor;
using GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor;
using GenialNet.Domain.Entities;

namespace GenialNet.Application.Mapper
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<CadastrarFornecedorRequest, Fornecedor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AtualizarFornecedorRequest, Fornecedor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
