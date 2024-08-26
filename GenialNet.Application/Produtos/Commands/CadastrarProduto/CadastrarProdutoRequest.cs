using GenialNet.Domain.Enums;
using MediatR;

namespace GenialNet.Application.Produtos.Commands.CadastrarProduto;

public record CadastrarProdutoRequest(string Descricao, string Marca, UnidadeMedida Medida) : IRequest<Guid>;
