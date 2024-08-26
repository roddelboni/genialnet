using GenialNet.Domain.Dtos;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Fornecedores.Queries.BuscarFornecedor
{
    public class BuscarFornecedorHandler : IRequestHandler<BuscarFornecedorRequest, FornecedorDto>
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public BuscarFornecedorHandler(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<FornecedorDto> Handle(BuscarFornecedorRequest request, CancellationToken cancellationToken)
        {
            return await _fornecedorRepository.BuscarFornecedorPorId(request.Id, cancellationToken);
        }
    }
}
