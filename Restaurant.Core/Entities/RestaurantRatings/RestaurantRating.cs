using System;
using DomainValidationCore.Validation;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Core.Validation.RestaurantRatings;

namespace Restaurant.Core.Entities.RestaurantRatings
{
    public partial class RestaurantRating
    {
        private readonly IGenericRepository<RestaurantRating> _restauranRepo;

       
        public int Id { get; set; }
        public string EmailUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
        public int RestaurantId { get; set; }

        public Restaurants.Restaurant Restaurant { get; set; }
        
       
    }
}