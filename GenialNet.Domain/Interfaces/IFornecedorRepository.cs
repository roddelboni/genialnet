using GenialNet.Domain.Entities;

namespace GenialNet.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        public Task<Guid> CriarFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken = default);
        public Task<Fornecedor> BuscarFornecedorPorId(Guid id, CancellationToken cancellationToken = default);
        public Task<List<Fornecedor>> BuscarFornecedoresAll(CancellationToken cancellationToken);
        public Task<Fornecedor> AtualizarFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken);
        public Task<bool> RemoverFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken);
    }
}
