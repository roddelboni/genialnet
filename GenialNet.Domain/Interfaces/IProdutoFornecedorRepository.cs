using GenialNet.Domain.Entities;

namespace GenialNet.Domain.Interfaces
{
    public interface IProdutoFornecedorRepository
    {
        Task<Guid> CriarProdutoFornecedor(ProdutoFornecedor produtoFornecedor, CancellationToken cancellationToken = default);
        Task<ProdutoFornecedor?> BuscarProdutoFornecedorPorId(Guid id, CancellationToken cancellationToken = default);
        Task<List<ProdutoFornecedor>> BuscarTodosProdutosFornecedores(CancellationToken cancellationToken = default);
        Task<ProdutoFornecedor> AtualizarProdutoFornecedor(ProdutoFornecedor produtoFornecedor, CancellationToken cancellationToken = default);
        Task<bool> RemoverProdutoFornecedor(Guid id, CancellationToken cancellationToken = default);
    }
}
