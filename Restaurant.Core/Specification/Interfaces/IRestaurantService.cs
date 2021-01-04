namespace Restaurant.Core.Specification.Interfaces
{
    public interface IRestaurantService
    {
        Entities.Restaurants.Restaurant CreateOrderAsync(Entities.Restaurants.Restaurant restaurant);

    }
}