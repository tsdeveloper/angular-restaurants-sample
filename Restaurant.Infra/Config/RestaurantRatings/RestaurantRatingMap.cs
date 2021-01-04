using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities.RestaurantRatings;

namespace Restaurant.Infra.Config.RestaurantRatings
{
    public class RestaurantRatingMap : IEntityTypeConfiguration<RestaurantRating>
    {
        public void Configure(EntityTypeBuilder<RestaurantRating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmailUser)
                .HasDefaultValue(200)
                .IsRequired();
            
            builder.Property(x => x.Rating)
                .IsRequired();
        }
    }
}