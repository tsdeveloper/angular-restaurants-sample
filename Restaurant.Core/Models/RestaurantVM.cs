using AutoMapper;
using FluentValidation;

namespace Restaurant.Core.Models
{
    [AutoMap(typeof(Entities.Restaurants.Restaurant), ReverseMap = true)]
    public class RestaurantCreateVM
    {
        public int Id { get; set; }
        public string EmailUser { get; set; }
        public string Rating { get; set; }
    }

    public class RestaurantCreateVMValidators : AbstractValidator<RestaurantCreateVM>
    {
        public RestaurantCreateVMValidators()
        {
            RuleFor(x => x.Rating)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is Required");
            
            RuleFor(x => x.EmailUser)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is Required");
        }
    }
    
    [AutoMap(typeof(Entities.Restaurants.Restaurant), ReverseMap = true)]
    public class RestaurantListGridVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
      
    }
}