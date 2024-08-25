using GenialNet.Data.Context;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GenialNet.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ReadContext _readContext;
        private readonly WriteContext _writeContext;

        public ProdutoRepository(ReadContext readContext, WriteContext writeContext) { 
            _readContext = readContext;
            _writeContext = writeContext;
        }

        public async Task<Guid> CriarProduto(Produto Produto, CancellationToken cancellationToken = default)
        {
            var ProdutoId = await _writeContext.Produtos.AddAsync(Produto);
            _writeContext.SaveChanges();
            return ProdutoId.Entity.Id;
        }

        public async Task<Produto> BuscarProdutoPorId(Guid id, CancellationToken cancellationToken = default)
        {
            return _readContext.Produtos.Where(f => f.Id == id).First();
        }

        public async Task<List<Produto>> BuscarProdutoesAll(CancellationToken cancellationToken)
        {
            return _readContext.Produtos.ToList();
        }

        public async Task<Produto> AtualizarProduto(Produto Produto, CancellationToken cancellationToken)
        {
            var ProdutoExistente = await _readContext.Produtos
                .FirstOrDefaultAsync(f => f.Id == Produto.Id);

            if (ProdutoExistente == null)
            {
                throw new ValidationException("Produto não existe");
            }

            ProdutoExistente.Descricao = Produto.Descricao;
            ProdutoExistente.Marca = Produto.Marca;
            ProdutoExistente.Medida = Produto.Medida;
            
            _writeContext.Entry(ProdutoExistente).State = EntityState.Modified;

            await _writeContext.SaveChangesAsync();

            return ProdutoExistente;
        }
    }
}
