using GenialNet.Domain.Enums;
using MediatR;

namespace GenialNet.Application.Produtos.Commands.AtualizarProduto;

public record AtualizarProdutoRequest(string Descricao, string Marca, UnidadeMedida Medida) : IRequest<bool>;

