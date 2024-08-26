using GenialNet.Data.Context;
using GenialNet.Domain.Dtos;
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

        public async Task<ProdutoDto> BuscarProdutoPorId(Guid id, CancellationToken cancellationToken = default)
        {
            var produto = _readContext.Produtos.Where(f => f.Id == id).First();
            return new ProdutoDto
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Marca = produto.Marca,
                Medida = produto.Medida
            };
        }

        public async Task<List<ProdutoDto>> BuscarProdutoesAll(CancellationToken cancellationToken)
        {
            var produto = _readContext.Produtos.ToList();
            return produto.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Descricao = p.Descricao,
                Marca = p.Marca,
                Medida = p.Medida
            }).ToList();
        }

        public async Task<ProdutoDto> AtualizarProduto(Produto Produto, CancellationToken cancellationToken)
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

            return new ProdutoDto
            {
                Id = ProdutoExistente.Id,
                Descricao = ProdutoExistente.Descricao,
                Marca = ProdutoExistente.Marca,
                Medida = ProdutoExistente.Medida
            };
        }

        public async Task<bool> RemoverFornecedor(Produto produto, CancellationToken cancellationToken)
        {
            var produtoId =  _writeContext.Produtos.Remove(produto);
            _writeContext.SaveChanges();
            return true;
        }
    }
}
