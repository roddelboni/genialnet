using GenialNet.Application.Fornecedores.Queries.ListarFornecedores;
using GenialNet.Domain.Dtos;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Produtoes.Queries.ListarProdutoes;


public class ListarProdutoHandler : IRequestHandler<ListarProdutosRequest, List<ProdutoDto>>
{
    private readonly IProdutoRepository _ProdutoRepository;

    public ListarProdutoHandler(IProdutoRepository ProdutoRepository)
    {
        _ProdutoRepository = ProdutoRepository;
    }

    public async Task<List<ProdutoDto>> Handle(ListarProdutosRequest request, CancellationToken cancellationToken)
    {
        return await _ProdutoRepository.BuscarProdutoesAll(cancellationToken);
    }
}
