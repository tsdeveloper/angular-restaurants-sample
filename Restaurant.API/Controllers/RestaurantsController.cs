using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Entities.RestaurantRatings;
using Restaurant.Core.Models;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Core.Specification.Restaurants;
using Restaurant.Core.Specification.Restaurants.Params;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Core.Entities.Restaurants.Restaurant> _restauranRepo;
        private readonly IRestaurantRatingService _restaurantService;

        public RestaurantsController(IMapper mapper, 
            IGenericRepository<Core.Entities.Restaurants.Restaurant> restauranRepo,
            IRestaurantRatingService restaurantService)
        {
            _mapper = mapper;
            _restauranRepo = restauranRepo;
            _restaurantService = restaurantService;
        }
        [HttpGet]
        [Route("all-restaurants")]
        public ActionResult<IReadOnlyList<RestaurantListGridVM>> GetFindAll(  [FromQuery] RestaurantAllParams restaurantAllParams)
        {
            
            var spec = new RestaurantAllSpecification(restaurantAllParams);
          
            var restaurantListVM = _mapper.Map<IReadOnlyList<RestaurantListGridVM>>(_restauranRepo.ListAsync(spec));

            return Ok(restaurantListVM);
        }
        
        [HttpPost]
        [Route("post-restaurant")]
        public ActionResult<RestaurantCreateVM> CreateRestaurant([FromQuery] RestaurantCreateVM restaurantCreateVm)
        {
            var validate = new RestaurantCreateVMValidators();
            var result = validate.Validate(restaurantCreateVm);
            
            if (!result.IsValid)
                return BadRequest("Error create restaurant");
            
            var restaurant = _mapper.Map<RestaurantRating>(restaurantCreateVm);
            var restaurantVM = _mapper.Map<RestaurantCreateVM>(
                _restaurantService.CreateOrderAsync(restaurant));

            if (restaurantVM == null) return BadRequest("Problem creating restaurant");

            return Ok(restaurantVM);
        }
    }

    public class RestaurantVM
    {
        public string Email { get; set; }
        public int Rate { get; set; }
    }
}