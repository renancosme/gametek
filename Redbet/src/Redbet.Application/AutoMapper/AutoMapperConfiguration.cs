using AutoMapper;

namespace Redbet.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new ViewModelToDomainMappingProfile());
                ps.AddProfile(new DomainToViewModelMappingProfile());
            });
        }
    }
}
