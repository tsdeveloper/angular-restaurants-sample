using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Restaurant.Core.AutoMapper.Restaurants;

namespace Restaurant.Core.AutoMapper
{
    public class MappingProfiles
    {
        public MapperConfiguration AddProfiles()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.AddExpressionMapping();
                x.AddProfile<RestaurantProfile>();
            });

            return config;
        }
    }
}