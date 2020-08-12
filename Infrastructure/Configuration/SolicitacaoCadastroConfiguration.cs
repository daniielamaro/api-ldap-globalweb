using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SolicitacaoCadastroConfiguration : IEntityTypeConfiguration<SolicitacaoCadastro>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCadastro> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(e => e.Name)
                .IsRequired();

            builder
                .Property(e => e.Email)
                .IsRequired();

            builder
                .Property(e => e.Motivo)
                .IsRequired();
        }
    }
}
