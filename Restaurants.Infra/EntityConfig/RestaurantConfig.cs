using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infra.EntityConfig;

public class RestaurantConfig: IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("Restaurants");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasMany(x => x.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);

        builder.OwnsOne(r => r.Address);
    }
}