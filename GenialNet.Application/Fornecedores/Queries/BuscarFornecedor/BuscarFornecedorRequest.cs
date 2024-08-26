using GenialNet.Domain.Dtos;
using MediatR;

namespace GenialNet.Application.Fornecedores.Queries.BuscarFornecedor;

public record BuscarFornecedorRequest(Guid Id) : IRequest<FornecedorDto>;

