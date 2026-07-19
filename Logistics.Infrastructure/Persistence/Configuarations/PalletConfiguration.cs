using Logistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Infrastructure.Persistence.Configurations;

public sealed class PalletConfiguration
    : IEntityTypeConfiguration<Pallet>
{
    public void Configure(
        EntityTypeBuilder<Pallet> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Weight);

        builder.OwnsOne(
            x => x.Dimensions,
            dimensions =>
            {
                dimensions.Property(x => x.Length)
                    .HasColumnName("Length");

                dimensions.Property(x => x.Width)
                    .HasColumnName("Width");

                dimensions.Property(x => x.Height)
                    .HasColumnName("Height");
            });
    }
}