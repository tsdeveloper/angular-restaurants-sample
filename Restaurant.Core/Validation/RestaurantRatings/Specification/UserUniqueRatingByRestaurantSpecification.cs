using System;
using DomainValidationCore.Interfaces.Specification;
using Restaurant.Core.Entities.RestaurantRatings;
using Restaurant.Core.Extensions;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Core.Specification.RestaurantRatings;
using Restaurant.Core.Specification.RestaurantRatings.Params;

namespace Restaurant.Core.Validation.RestaurantRatings.Specification
{
    public class UserUniqueRatingByRestaurantSpecification : ISpecification<RestaurantRating>
    {
        private readonly IGenericRepository<RestaurantRating> _restauranRepo;

        public UserUniqueRatingByRestaurantSpecification(IGenericRepository<RestaurantRating> restauranRepo)
        {
            _restauranRepo = restauranRepo;
            
        }
        public bool IsSatisfiedBy(RestaurantRating entity)
        {
            var paramsSpec = new RestaurantRatingByUserParams
            {
                CreatedAt = DateTime.Now,
                EmailUser = entity.EmailUser,
                RestaurantId = entity.RestaurantId
            };
            var spec = new RestaurantRatingByUserSpecification(paramsSpec);
            
            
            var result =  _restauranRepo.GetEntityWithSpec(spec);
            if (result != null)
            {
                /*if (result.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                    return false;*/
                
                var dtFirstDayWeek = DateTime.Now.FirstDayOfWeek();
                var dtLastDayWeek = DateTime.Now.LastDayOfWeek();
                
                if (result.CreatedAt.Between(dtFirstDayWeek,dtLastDayWeek))
                    return false;
            }

            return true;
        }
    }
}