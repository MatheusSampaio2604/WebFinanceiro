using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MappingData
{
    public class QuantidadesMapping : IEntityTypeConfiguration<Quantidades>
    {
        public void Configure(EntityTypeBuilder<Quantidades> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.Acoes).WithMany(x=>x.Quantidades).HasForeignKey(x=>x.AcaoId);
            builder.HasOne(x=>x.Fii).WithMany(x=>x.Quantidades).HasForeignKey(x=>x.FiiId);
            //builder.HasOne(x=>x.ApplicationUser).WithMany(x=>x.Quantidades).HasForeignKey(x=>x.UserId);
            
            builder.Property(x=>x.Id).HasColumnName("Id");
            builder.Property(x=>x.UserId).HasColumnName("UserId");
            builder.Property(x=>x.Quantidade).HasColumnName("Quantidade");
            builder.Property(x=>x.AcaoId).HasColumnName("AcaoId");
            builder.Property(x=>x.FiiId).HasColumnName("FiiId");
        }
    }
}