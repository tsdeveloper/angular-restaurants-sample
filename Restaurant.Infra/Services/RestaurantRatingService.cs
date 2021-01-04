using Restaurant.Core.Entities.RestaurantRatings;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Core.Validation.RestaurantRatings;

namespace Restaurant.Infra.Services
{
    public class RestaurantRatingService : IRestaurantRatingService
    {
        private readonly IGenericRepository<RestaurantRating> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public RestaurantRatingService(IGenericRepository<RestaurantRating> genericRepository,
            IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        
        }
        public RestaurantRating CreateOrderAsync(RestaurantRating restaurant)
        {
            var resultValidation = new RestaurantRatingEstaConsistenteValidation(_genericRepository).Validate(restaurant);
            
            if (!resultValidation.IsValid)
                return null;
            
            _unitOfWork.Repository<RestaurantRating>().Add(restaurant);
            
            // save to db
            var result = _unitOfWork.Complete();

            if (result <= 0) return null;


            return restaurant;
        }
    }
}