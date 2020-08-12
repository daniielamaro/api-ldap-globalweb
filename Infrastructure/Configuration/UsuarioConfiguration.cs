using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(u => u.Login)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .IsRequired();

            builder
                .HasOne(u => u.Role)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
