using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Restaurant.Core.Entities.RestaurantRatings;

namespace Restaurant.Core.Models
{
    [AutoMap(typeof(RestaurantRating), ReverseMap = true)]
    public class RestaurantRatingCreateVM
    {
        public int Id { get; set; }
        public string EmailUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Rating { get; set; }
        
        public int RestaurantId { get; set; }

        public RestaurantListGridVM Restaurant { get; set; }
    }

    public class RestaurantRatingCreateVMValidators : AbstractValidator<RestaurantRatingCreateVM>
    {
        public RestaurantRatingCreateVMValidators()
        {
            RuleFor(x => x.RestaurantId)
                .NotEmpty().GreaterThan(0).NotNull().WithMessage("{PropertyName} is Required");
            
            RuleFor(x => x.Rating)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is Required");
            
            RuleFor(x => x.EmailUser)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is Required");
        }
    }
    
    [AutoMap(typeof(Entities.Restaurants.Restaurant), ReverseMap = true)]
    public class RestaurantVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
      
    }
    
    public class RestaurantListGridVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
      
    }
    
   
    public class RestaurantWithRestaurantRatingsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public int TotalUserRating { get; set; }
    }
}