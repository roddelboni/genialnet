using AutoMapper;
using FluentValidation;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using MediatR;

namespace GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor
{
    public class CadastrarFornecedorHandler : IRequestHandler<CadastrarFornecedorRequest, Guid>
    {
        private readonly IValidator<CadastrarFornecedorRequest> _validator;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public CadastrarFornecedorHandler(IValidator<CadastrarFornecedorRequest> validator,
            IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _validator = validator;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CadastrarFornecedorRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ValidationException("Erro de validação", validationResult.Errors);            }

            var fornecedor = _mapper.Map<Fornecedor>(request);

            var retorno = await _fornecedorRepository.CriarFornecedor(fornecedor, cancellationToken);

            return retorno;
        }
    }
}
