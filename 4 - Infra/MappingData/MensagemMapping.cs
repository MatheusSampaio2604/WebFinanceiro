using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MappingData
{
    public class MessagemMapping : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Ativo).HasDefaultValue(true);
            builder.Property(x=>x.Titulo).HasMaxLength(255);
            // builder.HasOne(x=>x.ApplicationUser).WithMany(x=>x.Mensagem).HasForeignKey(x=>x.UserId);
            
            builder.Property(x=>x.Id).HasColumnName("Id");
            builder.Property(x=>x.UserId).HasColumnName("UserId");
            builder.Property(x=>x.Titulo).HasColumnName("Titulo");
            builder.Property(x=>x.DataCadastro).HasColumnName("DataCadastro");
            builder.Property(x=>x.DataAlteracao).HasColumnName("DataAlteracao");
            builder.Property(x=>x.Ativo).HasColumnName("Ativo");
        }
    }
}