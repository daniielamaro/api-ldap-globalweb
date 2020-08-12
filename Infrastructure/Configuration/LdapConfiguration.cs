using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class LdapConfiguration : IEntityTypeConfiguration<Ldap>
    {
        public void Configure(EntityTypeBuilder<Ldap> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(u => u.Host)
                .IsRequired();

            builder
                .Property(u => u.Dominio)
                .IsRequired();

            builder
                .Property(u => u.BaseDn)
                .IsRequired();
        }
    }
}
