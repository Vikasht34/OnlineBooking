using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace UtilityProject.Genric_Mapper
{
   public static class GenericMapper
    {
        public static TDestination SimpleMap<TSource, TDestination>(TSource source)
        {
            MapperConfiguration mapperConfiguration  = new MapperConfiguration(config =>
                {
                    config.CreateMap<TSource, TDestination>();
                });
            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<TDestination>(source);
        }

        public static IEnumerable<TDestination> SimpleMapToList<TSource, TDestination>(IEnumerable<TSource> source)
        {
            MapperConfiguration mapConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<TSource, TDestination>();
            });
            IMapper mapper = mapConfiguration.CreateMapper();
            return mapper.Map<IEnumerable<TDestination>>(source);
        }

    }
}
