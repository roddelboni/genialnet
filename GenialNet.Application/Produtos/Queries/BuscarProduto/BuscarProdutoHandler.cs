using GenialNet.Domain.Dtos;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Fornecedores.Queries.BuscarProduto;

public class BuscarProdutoHandler : IRequestHandler<BuscarProdutoRequest, ProdutoDto>
{
    private readonly IProdutoRepository _produtoRepository;

    public BuscarProdutoHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ProdutoDto> Handle(BuscarProdutoRequest request, CancellationToken cancellationToken)
    {
        return await _produtoRepository.BuscarProdutoPorId(request.Id, cancellationToken);
    }
}
