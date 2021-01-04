using Restaurant.Core.Specification.Restaurants.Params;

namespace Restaurant.Core.Specification.Restaurants
{
    public class RestaurantRatingByISpecification : BaseSpecification<Entities.Restaurants.Restaurant>
    {
        public RestaurantRatingByISpecification(RestaurantRatingByIdParams restaurantAllParams)
        : base(x => x.Id.Equals(restaurantAllParams.Id) &&
            x.IsCanceled.Equals(false))
        {
            AddOrderBy(x => x.Name);
            AddInclude(x => x.RestaurantRatings);
        }
    }
}