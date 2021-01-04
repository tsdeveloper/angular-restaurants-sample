using System.Collections.Generic;
using Restaurant.Core.Entities.RestaurantRatings;

namespace Restaurant.Core.Entities.Restaurants
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool? IsCanceled { get; set; }
        public IEnumerable<RestaurantRating> RestaurantRatings { get; set; } = new List<RestaurantRating>();
    }
}