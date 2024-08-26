using MediatR;

namespace GenialNet.Application.Fornecedores.Commands.AtualizarFornecedor;

public record AtualizarFornecedorRequest(Guid Id, string Nome, string Cnpj, string Endereco, string Telefone) : IRequest<bool>;
