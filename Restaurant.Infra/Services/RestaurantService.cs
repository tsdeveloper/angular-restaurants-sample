using Restaurant.Core.Specification.Interfaces;

namespace Restaurant.Infra.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IGenericRepository<Core.Entities.Restaurants.Restaurant> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public RestaurantService(IGenericRepository<Core.Entities.Restaurants.Restaurant> genericRepository,
            IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        
        }
        public Core.Entities.Restaurants.Restaurant CreateOrderAsync(Core.Entities.Restaurants.Restaurant restaurant)
        {
            _unitOfWork.Repository<Core.Entities.Restaurants.Restaurant>().Add(restaurant);

            // save to db
            var result = _unitOfWork.Complete();

            if (result <= 0) return null;


            return restaurant;
        }
    }
}