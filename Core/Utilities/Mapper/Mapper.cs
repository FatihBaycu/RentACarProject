using Mapster;

namespace Core.Utilities.Mapper
{
    public class Mapper:IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }
    }
}