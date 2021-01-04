using AutoMapper;
using Restaurant.Core.Entities.RestaurantRatings;
using Restaurant.Core.Models;

namespace Restaurant.Core.AutoMapper.Restaurants
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Entities.Restaurants.Restaurant, RestaurantListGridVM>().ReverseMap();
            CreateMap<Entities.Restaurants.Restaurant, RestaurantCreateVM>().ReverseMap();
            CreateMap<RestaurantRating, RestaurantCreateVM>().ReverseMap();
        }
    }
}