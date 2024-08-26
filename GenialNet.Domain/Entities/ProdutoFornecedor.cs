using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenialNet.Domain.Entities
{
    public class ProdutoFornecedor
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }

        [ForeignKey("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDeCompra { get; set; }

        public Produto Produto { get; set; } = new Produto();
        public Fornecedor Fornecedor { get; set; } = new Fornecedor();
    }
}
