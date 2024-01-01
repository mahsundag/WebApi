using AutoMapper;
using Atolla.Api.Framework.Models.Common;
using Atolla.Core.Mapper;
using Atolla.Domain.General;

namespace Atolla.Api.Framework.Profiles
{
    public class ModelEntityProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 0;
        public ModelEntityProfile()
        {
            CreateMap<Parameter, ParameterModel>().ReverseMap();
            CreateMap<Group, GroupModel>().ReverseMap();
            CreateMap<Configuration, ConfigurationModel>().ReverseMap();
            CreateMap<Localization, LocalizationModel>().ReverseMap();
        }
    }
}
