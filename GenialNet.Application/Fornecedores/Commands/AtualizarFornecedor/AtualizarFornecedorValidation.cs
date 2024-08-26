using FluentValidation;
using GenialNet.Domain.Utils;

namespace GenialNet.Application.Fornecedores.Commands.AtualizarFornecedor;

public class AtualizarFornecedorValidation : AbstractValidator<AtualizarFornecedorRequest>
{
    private readonly ValidarCnpj _cnpjValidator;

    public AtualizarFornecedorValidation()
    {

        _cnpjValidator = new ValidarCnpj();

        RuleFor(fornecedor => fornecedor.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .Length(1, 400).WithMessage("O nome deve ter entre 1 e 400 caracteres.");

        RuleFor(fornecedor => fornecedor.Cnpj)
            .NotEmpty().WithMessage("O CNPJ é obrigatório.")
            .Length(14).WithMessage("O CNPJ deve ter exatamente 14 caracteres.")
            .Must(_cnpjValidator.IsValid).WithMessage("O CNPJ informado é inválido.");

        RuleFor(fornecedor => fornecedor.Endereco)
            .NotEmpty().WithMessage("O endereço é obrigatório.")
            .MaximumLength(500).WithMessage("O endereço deve ter no máximo 500 caracteres.");

        RuleFor(fornecedor => fornecedor.Telefone)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .Length(10, 14).WithMessage("O telefone deve ter entre 10 e 14 caracteres.");
    }
}
