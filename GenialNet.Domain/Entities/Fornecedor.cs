using System.ComponentModel.DataAnnotations;

namespace GenialNet.Domain.Entities;

public class Fornecedor
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(400)]
    public string Nome { get; set; } = string.Empty!;

    [Required]
    [MaxLength(14)]
    public string Cnpj { get; set; } = string.Empty!;

    [Required]
    [MaxLength(500)]
    public string Endereco {  get; set; } = string.Empty!;

    [Required]
    [MaxLength(14)]
    public string Telefone {  get; set; } = string.Empty!;
    public IList<ProdutoFornecedor> ProdutoFornecedores { get; set; } = new List<ProdutoFornecedor>();
}
