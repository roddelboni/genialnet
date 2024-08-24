using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor
{
    public class CadastrarFornecedorHandler : IRequestHandler<CadastrarFornecedorRequest, Guid>
    {
        public async Task<Guid> Handle(CadastrarFornecedorRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
