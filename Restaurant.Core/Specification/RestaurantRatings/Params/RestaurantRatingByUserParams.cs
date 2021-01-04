using System;

namespace Restaurant.Core.Specification.RestaurantRatings.Params
{
    public class RestaurantRatingByUserParams
    {
        public string EmailUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RestaurantId { get; set; }
    }
}