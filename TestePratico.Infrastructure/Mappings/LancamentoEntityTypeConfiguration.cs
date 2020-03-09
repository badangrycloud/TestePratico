using TestePratico.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace TestePratico.Infrastructure.Mappings
{
    class LancamentoEntityTypeConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ContaCorrenteId).IsRequired();
            builder.Property(x => x.TipoOperacao).IsRequired();
            builder.Property(x => x.Valor).HasColumnType<decimal>("numeric").IsRequired();
            builder.Property(x => x.DataOperacao).IsRequired();
        }
    }
}
