using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MappingIdentity
{
    public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.CPF).HasColumnName("CPF").HasMaxLength(14);
            builder.Property(x => x.TipoUsuario).HasColumnName("UserType");
        }
    }
}