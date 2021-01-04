using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Entities.RestaurantRatings;
using Restaurant.Core.Extensions;
using Restaurant.Core.Models;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Core.Specification.Restaurants;
using Restaurant.Core.Specification.Restaurants.Params;
using Restaurant.Infra.Data;


namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Core.Entities.Restaurants.Restaurant> _restauranRepo;
        private readonly IRestaurantRatingService _restaurantService;
        private readonly AppStoreContext _appStoreContext;

        public RestaurantsController(IMapper mapper, 
            IGenericRepository<Core.Entities.Restaurants.Restaurant> restauranRepo,
            IRestaurantRatingService restaurantService, AppStoreContext appStoreContext)
        {
            _mapper = mapper;
            _restauranRepo = restauranRepo;
            _restaurantService = restaurantService;
            _appStoreContext = appStoreContext;
        }
        [HttpGet]
        [Route("all-restaurants")]
        public ActionResult<IReadOnlyList<RestaurantListGridVM>> GetFindAll(  [FromQuery] RestaurantAllParams restaurantAllParams)
        {
        
            var spec = new RestaurantAllSpecification(restaurantAllParams);
          
            var restaurantListVM = _mapper.Map<IReadOnlyList<RestaurantListGridVM>>(_restauranRepo.ListAsync(spec));

            return Ok(restaurantListVM);
        }
        
        [HttpGet]
        [Route("restaurant-rating-byid")]
        public ActionResult<RestaurantWithRestaurantRatingsVM> GetRestaurantRatingById(  [FromQuery] RestaurantRatingByIdParams restaurantRatingByIdParams)
        {
           
           
            var spec = new RestaurantRatingByISpecification(restaurantRatingByIdParams);
          
            var restaurantListVM = _mapper.Map<RestaurantWithRestaurantRatingsVM>(_restauranRepo.GetEntityWithSpec(spec));

            return Ok(restaurantListVM);
        }
        
        [HttpPost]
        [Route("post-restaurant")]
        public ActionResult<RestaurantRatingCreateVM> CreateRestaurant([FromQuery] RestaurantRatingCreateVM restaurantCreateVm)
        {

            
            var validate = new RestaurantRatingCreateVMValidators();
            var result = validate.Validate(restaurantCreateVm);
            
            if (!result.IsValid)
                return BadRequest("Error create restaurant");
            try
            {
                var restaurant = _mapper.Map<RestaurantRating>(restaurantCreateVm);
                var restaurantRatingVM = _mapper.Map<RestaurantRatingCreateVM>(
                    _restaurantService.CreateOrderAsync(restaurant));
                
                var spec = new RestaurantByIdSpecification(new RestaurantByIdParams {Id = restaurantCreateVm.RestaurantId});
          
                var restaurantVM = _mapper.Map<RestaurantVM>(_restauranRepo.GetEntityWithSpec(spec));

                if (restaurantVM == null) return BadRequest("Problem creating restaurant");

                return Ok(restaurantVM);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }

}