using Microsoft.EntityFrameworkCore;
using TestePratico.Infrastructure.Mappings;
using TestePratico.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Infrastructure.DataContexts
{
    public class TestePraticoDataContext : DbContext
    {
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }

        public static string ConnectionString;

        public TestePraticoDataContext() { }
        public TestePraticoDataContext(DbContextOptions<TestePraticoDataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString ?? @"Server=tcp:127.0.0.1,5433;Database=TestePratico;User Id=sa;Password=TestePratico123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaCorrenteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LancamentoEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
