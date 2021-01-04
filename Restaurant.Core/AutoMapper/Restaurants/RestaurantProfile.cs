using System.Linq;
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
            CreateMap<Entities.Restaurants.Restaurant, RestaurantRatingCreateVM>().ReverseMap();
            CreateMap<RestaurantRating, RestaurantRatingCreateVM>().ReverseMap();
            CreateMap<RestaurantListGridVM, RestaurantRatingCreateVM>().ReverseMap();
            CreateMap<Entities.Restaurants.Restaurant, RestaurantWithRestaurantRatingsVM>()
                .ForMember(x => x.Rating, 
                    o => o.MapFrom<RatingResolver>())
                .ForMember(x => x.TotalUserRating, 
                    o => o.MapFrom<TotalUserRatingResolver>())
                .ReverseMap();
        }
    }

    public class TotalUserRatingResolver: IValueResolver<Entities.Restaurants.Restaurant, RestaurantWithRestaurantRatingsVM, int>
    {
        public int Resolve(Entities.Restaurants.Restaurant source, RestaurantWithRestaurantRatingsVM destination, int member, ResolutionContext context)
        {
            if (source.RestaurantRatings.Any())
            {
                destination.TotalUserRating = source.RestaurantRatings.Count();
                return destination.TotalUserRating;
            }
            return 0;
        }
    }

    public class RatingResolver : IValueResolver<Entities.Restaurants.Restaurant, RestaurantWithRestaurantRatingsVM, int>
    {
        public int Resolve(Entities.Restaurants.Restaurant source, RestaurantWithRestaurantRatingsVM destination, int member, ResolutionContext context)
        {
            if (source.RestaurantRatings.Any())
            {
                destination.Rating = source.RestaurantRatings.Sum(x => x.Rating);

                return destination.Rating;
            }
            return 0;
        }
    }
}