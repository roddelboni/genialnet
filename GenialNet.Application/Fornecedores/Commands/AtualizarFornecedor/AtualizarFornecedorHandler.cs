using AutoMapper;
using FluentValidation;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Fornecedores.Commands.AtualizarFornecedor
{
    public class AtualizarFornecedorHandler : IRequestHandler<AtualizarFornecedorRequest, bool>
    {
        private readonly IValidator<AtualizarFornecedorRequest> _validator;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public AtualizarFornecedorHandler(IValidator<AtualizarFornecedorRequest> validator,
            IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _validator = validator;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AtualizarFornecedorRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ValidationException("Erro de validação", validationResult.Errors);
            }

            var fornecedor = _mapper.Map<Fornecedor>(request);

            var resultado = await _fornecedorRepository.AtualizarFornecedor(fornecedor, cancellationToken);

            return resultado != null;
        }
    }
}
