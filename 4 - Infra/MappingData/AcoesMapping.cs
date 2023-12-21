using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MappingData
{
    public class AcoesMapping : IEntityTypeConfiguration<Acoes>
    {
        public void Configure(EntityTypeBuilder<Acoes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome).HasColumnName("Nome");

        }
    }
}