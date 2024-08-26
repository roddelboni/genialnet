using GenialNet.Domain.Dtos;
using GenialNet.Domain.Entities;

namespace GenialNet.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<Guid> CriarProduto(Produto Produto, CancellationToken cancellationToken = default);
        public Task<ProdutoDto> BuscarProdutoPorId(Guid id, CancellationToken cancellationToken = default);
        public Task<List<ProdutoDto>> BuscarProdutoesAll(CancellationToken cancellationToken);
        public Task<ProdutoDto> AtualizarProduto(Produto Produto, CancellationToken cancellationToken);
        public Task<bool> RemoverFornecedor(Produto produto, CancellationToken cancellationToken);       
    }
}
