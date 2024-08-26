using AutoMapper;
using FluentValidation;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Produtos.Commands.CadastrarProduto
{
    public class CadastrarProdutoHandler : IRequestHandler<CadastrarProdutoRequest, Guid>
    {
        private readonly IValidator<CadastrarProdutoRequest> _validator;
        private readonly IProdutoRepository _ProdutoRepository;
        private readonly IMapper _mapper;

        public CadastrarProdutoHandler(IValidator<CadastrarProdutoRequest> validator,
            IProdutoRepository ProdutoRepository, IMapper mapper)
        {
            _validator = validator;
            _ProdutoRepository = ProdutoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CadastrarProdutoRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ValidationException("Erro de validação", validationResult.Errors);
            }

            var Produto = _mapper.Map<Produto>(request);

            var retorno = await _ProdutoRepository.CriarProduto(Produto, cancellationToken);

            return retorno;
        }
    }
}

