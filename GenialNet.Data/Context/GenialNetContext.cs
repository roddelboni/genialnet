using GenialNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenialNet.Data.Context
{
    public class GenialNetContext : DbContext
    {
        public GenialNetContext(DbContextOptions<GenialNetContext> options)
            : base(options) { }


        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Fornecedor> Fornecedores { get; set; } = null!;

    }
}
