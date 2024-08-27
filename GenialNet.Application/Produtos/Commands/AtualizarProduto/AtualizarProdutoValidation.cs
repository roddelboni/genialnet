using FluentValidation;

namespace GenialNet.Application.Produtos.Commands.AtualizarProduto;

public class AtualizarProdutoValidation : AbstractValidator<AtualizarProdutoRequest>
{
    public AtualizarProdutoValidation()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
            .MaximumLength(500).WithMessage("A descrição do produto não pode exceder 500 caracteres.");

        RuleFor(x => x.Marca)
            .NotEmpty().WithMessage("A marca do produto é obrigatória.")
            .MaximumLength(100).WithMessage("A marca do produto não pode exceder 100 caracteres.");

        RuleFor(x => x.Medida)
            .IsInEnum().WithMessage("A unidade de medida informada é inválida.");
    }
}
