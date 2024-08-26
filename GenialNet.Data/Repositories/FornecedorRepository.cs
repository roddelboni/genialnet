using GenialNet.Data.Context;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GenialNet.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        private readonly ReadContext _readContext;
        private readonly WriteContext _writeContext;

        public FornecedorRepository(ReadContext readContext, WriteContext writeContext)
        {
            _readContext = readContext;
            _writeContext = writeContext;
        }

        public async Task<Guid> CriarFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken = default)
        {
            var fornecedorId = await _writeContext.Fornecedores.AddAsync(fornecedor);
            _writeContext.SaveChanges();
            return fornecedorId.Entity.Id;
        }

        public async Task<Fornecedor> BuscarFornecedorPorId(Guid id, CancellationToken cancellationToken = default)
        {
           return _readContext.Fornecedores.Where(f => f.Id == id).First();
        }

        public async Task<List<Fornecedor>> BuscarFornecedoresAll(CancellationToken cancellationToken)
        {
            return _readContext.Fornecedores.ToList();
        }

        public async Task<Fornecedor> AtualizarFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken)
        {            
            var fornecedorExistente = await _readContext.Fornecedores
                .FirstOrDefaultAsync(f => f.Id == fornecedor.Id);

            if (fornecedorExistente == null)
            {
                throw new ValidationException("Fornecedor não existe");
            }
            
            fornecedorExistente.Nome = fornecedor.Nome;
            fornecedorExistente.Cnpj = fornecedor.Cnpj;
            fornecedorExistente.Endereco = fornecedor.Endereco;
            fornecedorExistente.Telefone = fornecedor.Telefone;
          
            _writeContext.Entry(fornecedorExistente).State = EntityState.Modified;

            await _writeContext.SaveChangesAsync();

            return fornecedorExistente;
        }

        public async Task<bool> RemoverFornecedor(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            var fornecedorId = _writeContext.Fornecedores.Remove(fornecedor);
            _writeContext.SaveChanges();
            return true;

        }
    }
}
