using GenialNet.Data.Context;
using GenialNet.Domain.Interfaces;

namespace GenialNet.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ReadContext _readContext;
        private readonly WriteContext _writeContext;
        public async Task<Guid> CriarAsync(TEntity entity)
        {
            var retorno = await _writeContext.AddAsync(entity);
            await _writeContext.SaveChangesAsync();

            var idProperty = retorno.Entity.GetType().GetProperty("Id");
            if (idProperty == null)
            {
                throw new InvalidOperationException("A entidade não possui uma propriedade 'Id'.");
            }

            return (Guid)idProperty.GetValue(retorno.Entity);
        }
    }
}
