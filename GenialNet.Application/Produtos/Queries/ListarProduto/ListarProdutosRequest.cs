using GenialNet.Domain.Dtos;
using MediatR;

namespace GenialNet.Application.Fornecedores.Queries.ListarFornecedores;

public record ListarProdutosRequest : IRequest<List<ProdutoDto>>;
