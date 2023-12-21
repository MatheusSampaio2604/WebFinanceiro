using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MappingData
{
    public class ValroesMapping : IEntityTypeConfiguration<Valores>
    {
        public void Configure(EntityTypeBuilder<Valores> builder)
        {

            builder.HasKey(x => x.Id);
            //builder.Property
            builder.HasOne(x => x.Quantidades).WithMany(x => x.Valores).HasForeignKey(x => x.QuantidadeId);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.QuantidadeId).HasColumnName("QuatidadeId");
            builder.Property(x => x.Valor).HasColumnName("Valor");
            builder.Property(x => x.DataCompra).HasColumnName("DataCompra");

        }
    }
}