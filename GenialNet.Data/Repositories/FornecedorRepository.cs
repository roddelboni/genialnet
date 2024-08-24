using GenialNet.Data.Context;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
