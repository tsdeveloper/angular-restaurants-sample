using Restaurant.Core.Specification.Restaurants.Params;

namespace Restaurant.Core.Specification.Restaurants
{
    public class RestaurantByIdSpecification : BaseSpecification<Entities.Restaurants.Restaurant>
    {
        public RestaurantByIdSpecification(RestaurantByIdParams restaurantByIdParams)
        : base(x => x.Id == restaurantByIdParams.Id)
        {
            AddOrderBy(x => x.Name);
           
        }
    }
}