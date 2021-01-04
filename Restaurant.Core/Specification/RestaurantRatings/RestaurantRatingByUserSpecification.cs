using System;

using Restaurant.Core.Entities.RestaurantRatings;
using Restaurant.Core.Specification.RestaurantRatings.Params;

namespace Restaurant.Core.Specification.RestaurantRatings
{
    public class RestaurantRatingByUserSpecification : BaseSpecification<RestaurantRating>
    {
        public RestaurantRatingByUserSpecification(RestaurantRatingByUserParams restaurantAllParams)
        : base(x => x.EmailUser.Equals(restaurantAllParams.EmailUser) &&
                    x.RestaurantId.Equals(restaurantAllParams.RestaurantId)
                    )
        {
            
        }
    }
}