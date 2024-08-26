using GenialNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenialNet.Data.Context
{
    public class GenialNetContext : DbContext
    {
        public GenialNetContext(DbContextOptions<GenialNetContext> options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=genialnet;User Id=sa;Password=P@ssw0rd!;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoFornecedor>()
                .HasKey(pf => new { pf.ProdutoId, pf.FornecedorId });

            modelBuilder.Entity<ProdutoFornecedor>()
                .HasOne(pf => pf.Produto)
                .WithMany(p => p.ProdutoFornecedores)
                .HasForeignKey(pf => pf.ProdutoId);

            modelBuilder.Entity<ProdutoFornecedor>()
                .HasOne(pf => pf.Fornecedor)
                .WithMany(f => f.ProdutoFornecedores)
                .HasForeignKey(pf => pf.FornecedorId);
        }

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Fornecedor> Fornecedores { get; set; } = null!;
        public DbSet<ProdutoFornecedor> ProdutoFornecedores { get; set; } = null!;

    }
}
