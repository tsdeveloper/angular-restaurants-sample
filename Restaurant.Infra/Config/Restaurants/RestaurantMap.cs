using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurant.Infra.Config.Restaurants
{
    public class RestaurantMap : IEntityTypeConfiguration<Core.Entities.Restaurants.Restaurant>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Restaurants.Restaurant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasDefaultValue(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasDefaultValue(200)
                .IsRequired(false);

            builder.Property(x => x.Image)
                .IsRequired(false);

            builder.Property(x => x.IsCanceled)
                .IsRequired(false);

        }
    }
}