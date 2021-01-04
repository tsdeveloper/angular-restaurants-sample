using Restaurant.Core.Specification.Restaurants.Params;

namespace Restaurant.Core.Specification.Restaurants
{
    public class RestaurantAllSpecification : BaseSpecification<Entities.Restaurants.Restaurant>
    {
        public RestaurantAllSpecification(RestaurantAllParams restaurantAllParams)
        : base(x => restaurantAllParams.Name == null ||  x.Name.Equals(restaurantAllParams.Name) &&
            x.IsCanceled.Equals(false))
        {
            AddOrderBy(x => x.Name);
        }
    }
}