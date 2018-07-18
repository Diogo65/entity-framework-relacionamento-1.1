using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get;set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cria uma chava primária composta para a tabela PromocaoProduto
            modelBuilder.Entity<PromocaoProduto>().HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LojaDB; Trusted_Connection = true;");
        }
    }
}