using FluentValidation;
using GenialNet.Domain.Entities;
using GenialNet.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor
{
    public class CadastrarFornecedorHandler : IRequestHandler<CadastrarFornecedorRequest, Guid>
    {
        private readonly IValidator<CadastrarFornecedorRequest> _validator;
        private readonly IFornecedorRepository _fornecedorRepository;

        public CadastrarFornecedorHandler(IValidator<CadastrarFornecedorRequest> validator,
            IFornecedorRepository fornecedorRepository)
        {
            _validator = validator;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Guid> Handle(CadastrarFornecedorRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ValidationException("Erro de validação", validationResult.Errors);
            }




            _fornecedorRepository.


        }
    }
}
