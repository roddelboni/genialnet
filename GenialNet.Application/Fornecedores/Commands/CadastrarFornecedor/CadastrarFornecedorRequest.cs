using MediatR;

namespace GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor;

    public record CadastrarFornecedorRequest(string Nome, string Cnpj,
        string Endereco, string Telefone) : IRequest<Guid>;

