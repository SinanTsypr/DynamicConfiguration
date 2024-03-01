using AutoMapper;
using SecilStore.ApplicationCore.Entities;
using SecilStore.Web.Models;

namespace SecilStore.Web.MappingProfiles
{
    public class ConfigurationMappingProfile : Profile
    {
        public ConfigurationMappingProfile()
        {
            CreateMap<ConfigurationViewModel, Configuration>();
            CreateMap<UpdateConfigurationViewModel, Configuration>();
        }
    }
}
