using TestePratico.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestePratico.Infrastructure.Mappings
{
    class ContaCorrenteEntityTypeConfiguration : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("ContaCorrente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Agencia).HasMaxLength(4).IsRequired();
            builder.Property(x => x.NumeroConta).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Digito).HasMaxLength(2).IsRequired();
        }
    }
}
