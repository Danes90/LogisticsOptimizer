using Logistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Infrastructure.Persistence.Configurations;

public sealed class TruckConfiguration
    : IEntityTypeConfiguration<Truck>
{
    public void Configure(
        EntityTypeBuilder<Truck> builder)
    {
        builder.HasKey(x => x.Id);

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