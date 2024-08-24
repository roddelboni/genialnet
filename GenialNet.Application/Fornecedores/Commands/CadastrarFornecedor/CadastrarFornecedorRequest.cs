using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor
{
    public record CadastrarFornecedorRequest : IRequest<Guid>
    {
    }
}
