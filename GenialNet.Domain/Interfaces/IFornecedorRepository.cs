using GenialNet.Domain.Dtos;
using GenialNet.Domain.Entities;

namespace GenialNet.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        public Task<Guid> CriarFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken = default);
        public Task<FornecedorDto> BuscarFornecedorPorId(Guid id, CancellationToken cancellationToken = default);
        public Task<List<FornecedorDto>> BuscarFornecedoresAll(CancellationToken cancellationToken);
        public Task<FornecedorDto> AtualizarFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken);
        public Task<bool> RemoverFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken);
    }
}
