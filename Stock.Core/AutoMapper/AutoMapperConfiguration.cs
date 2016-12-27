using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Mappers;

namespace Stock.Core.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        private static MappingEngine _mapper;

        private static readonly object SyncRoot = new object();

        public static MappingEngine Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    lock (SyncRoot)
                    {
                        if (_mapper == null)
                        {
                            var config = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);

                            foreach (var profile in Assembly.GetAssembly(typeof(AutoMapperConfiguration)).GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t)))
                            {
                                config.AddProfile(Activator.CreateInstance(profile) as Profile);
                            }

                            _mapper = new MappingEngine(config);
                        }
                    }
                }

                return _mapper;
            }
        }
    }
}
