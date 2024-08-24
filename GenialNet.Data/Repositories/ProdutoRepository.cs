using GenialNet.Data.Context;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;

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
    }
}
