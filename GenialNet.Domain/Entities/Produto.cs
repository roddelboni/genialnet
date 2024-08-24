using GenialNet.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GenialNet.Domain.Entities
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(400)]
        public string Descricao { get; set; }= string.Empty!;

        [Required]
        [MaxLength(100)]
        public string Marca { get; set; } = string.Empty!;

        [Required]
        public UnidadeMedida Medida { get; set; }

        public IList<ProdutoFornecedor> ProdutoFornecedores { get; set; } = new List<ProdutoFornecedor>();
    }
}
