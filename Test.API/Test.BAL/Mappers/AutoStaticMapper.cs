using AutoMapper;

namespace Test.BAL.Mappers
{
    public class AutoStaticMapper<TSource, TDestination>
    {
        public static List<TDestination> MapList(List<TSource> source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = new Mapper(config);
            List<TDestination> list = mapper.Map<List<TDestination>>(source);
            return list;
        }

        public static List<TDestination> MapListWithConfig(List<TSource> source, MapperConfiguration config)
        {
            var mapper = new Mapper(config);
            List<TDestination> list = mapper.Map<List<TDestination>>(source);
            return list;
        }

        public static TDestination MapObject(TSource source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = new Mapper(config);
            TDestination obj = mapper.Map<TDestination>(source);
            return obj;
        }

        public static TDestination MapObjectWithConfig(TSource source, MapperConfiguration config)
        {
            var mapper = new Mapper(config);
            TDestination _object = mapper.Map<TDestination>(source);
            return _object;
        }
    }

}
