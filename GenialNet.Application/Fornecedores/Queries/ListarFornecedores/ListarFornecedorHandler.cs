using GenialNet.Domain.Dtos;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Fornecedores.Queries.ListarFornecedores
{

    public class ListarFornecedorHandler : IRequestHandler<ListarFornecedoresRequest, List<FornecedorDto>>
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public ListarFornecedorHandler(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<List<FornecedorDto>> Handle(ListarFornecedoresRequest request, CancellationToken cancellationToken)
        {
            return await _fornecedorRepository.BuscarFornecedoresAll(cancellationToken);
        }
    }
}
