using AutoMapper;
using System.Collections.Generic;

namespace Cross_Cutting.Mapping
{
    public class CustomMapper<TSource, TDestination>
    {
        public CustomMapper()
        {
            Mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()).CreateMapper();
        }

        public IMapper Mapper { get; set; }

        public TDestination Map(TSource from) => Mapper.Map<TDestination>(from);

        public IEnumerable<TDestination> MapCollection(IEnumerable<TSource> from) => Mapper.Map<IEnumerable<TDestination>>(from);
    }
}
