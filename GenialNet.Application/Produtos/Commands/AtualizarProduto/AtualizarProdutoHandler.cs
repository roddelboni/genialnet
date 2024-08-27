using AutoMapper;
using FluentValidation;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Produtos.Commands.AtualizarProduto
{
    public class AtualizarProdutoHandler: IRequestHandler<AtualizarProdutoRequest, bool>
    {
        private readonly IValidator<AtualizarProdutoRequest> _validator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public AtualizarProdutoHandler(IValidator<AtualizarProdutoRequest> validator,
            IProdutoRepository produtoRepository, IMapper mapper)
        {
            _validator = validator;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AtualizarProdutoRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ValidationException("Erro de validação", validationResult.Errors);
            }

            var produto = _mapper.Map<Produto>(request);

            var resultado = await _produtoRepository.AtualizarProduto(produto, cancellationToken);

            return resultado != null;
        }
    }
}
