using GenialNet.Data.Context;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GenialNet.Data.Repositories
{
    public class ProdutoFornecedorRepository : BaseRepository<ProdutoFornecedor>, IProdutoFornecedorRepository
    {
        private readonly ReadContext _readContext;
        private readonly WriteContext _writeContext;

        public ProdutoFornecedorRepository(ReadContext readContext, WriteContext writeContext)
        {
            _readContext = readContext;
            _writeContext = writeContext;
        }

        public async Task<Guid> CriarProdutoFornecedor(ProdutoFornecedor produtoFornecedor, CancellationToken cancellationToken = default)
        {
            var produtoFornecedorId = await _writeContext.ProdutoFornecedores.AddAsync(produtoFornecedor, cancellationToken);
            await _writeContext.SaveChangesAsync(cancellationToken);
            return produtoFornecedorId.Entity.Id;
        }

        public async Task<ProdutoFornecedor?> BuscarProdutoFornecedorPorId(Guid id, CancellationToken cancellationToken = default)
        {
            return await _readContext.ProdutoFornecedores
                .Include(pf => pf.Produto)
                .Include(pf => pf.Fornecedor)
                .FirstOrDefaultAsync(pf => pf.Id == id, cancellationToken);
        }

        public async Task<List<ProdutoFornecedor>> BuscarTodosProdutosFornecedores(CancellationToken cancellationToken = default)
        {
            return await _readContext.ProdutoFornecedores
                .Include(pf => pf.Produto)
                .Include(pf => pf.Fornecedor)
                .ToListAsync(cancellationToken);
        }

        public async Task<ProdutoFornecedor> AtualizarProdutoFornecedor(ProdutoFornecedor produtoFornecedor, CancellationToken cancellationToken = default)
        {
            var produtoFornecedorExistente = await _readContext.ProdutoFornecedores
                .FirstOrDefaultAsync(pf => pf.Id == produtoFornecedor.Id, cancellationToken);

            if (produtoFornecedorExistente == null)
            {
                throw new ValidationException("ProdutoFornecedor não existe");
            }

            produtoFornecedorExistente.ProdutoId = produtoFornecedor.ProdutoId;
            produtoFornecedorExistente.FornecedorId = produtoFornecedor.FornecedorId;
            produtoFornecedorExistente.ValorDeCompra = produtoFornecedor.ValorDeCompra;

            _writeContext.Entry(produtoFornecedorExistente).State = EntityState.Modified;

            await _writeContext.SaveChangesAsync(cancellationToken);

            return produtoFornecedorExistente;
        }

        public async Task<bool> RemoverProdutoFornecedor(Guid id, CancellationToken cancellationToken = default)
        {
            var produtoFornecedor = await _writeContext.ProdutoFornecedores.FindAsync(new object[] { id }, cancellationToken);

            if (produtoFornecedor == null)
            {
                return false;
            }

            _writeContext.ProdutoFornecedores.Remove(produtoFornecedor);
            await _writeContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
