using GenialNet.Domain.Dtos;
using MediatR;

namespace GenialNet.Application.Fornecedores.Queries.BuscarProduto;

public record BuscarProdutoRequest(Guid Id) : IRequest<ProdutoDto>;

