using Restaurant.Core.Entities.RestaurantRatings;

namespace Restaurant.Core.Specification.Interfaces
{
    public interface IRestaurantRatingService
    {
        RestaurantRating CreateOrderAsync(RestaurantRating restaurantRating);

    }
}