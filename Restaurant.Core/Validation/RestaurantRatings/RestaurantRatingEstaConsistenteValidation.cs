using DomainValidationCore.Validation;
using Restaurant.Core.Entities.RestaurantRatings;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Core.Validation.RestaurantRatings.Specification;

namespace Restaurant.Core.Validation.RestaurantRatings
{
    public class RestaurantRatingEstaConsistenteValidation : Validator<RestaurantRating>
    {
        public RestaurantRatingEstaConsistenteValidation(IGenericRepository<RestaurantRating> _restauranRepo)
        {
            var loginAvalicaoUnicoDoDia = new UserUniqueRatingByRestaurantSpecification(_restauranRepo);
            
            base.Add("loginAvalicaoUnicoDoDia", new Rule<RestaurantRating>(loginAvalicaoUnicoDoDia, "Login já avaliou esse restaurante hoje."));
        }
    }
}