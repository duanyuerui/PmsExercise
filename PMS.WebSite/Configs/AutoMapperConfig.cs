using AutoMapper;

namespace PMS.WebSite.Configs
{

    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityToDto>();
                cfg.AddProfile<DtoToEntity>();
            }));
        }
    }

    /// <summary>
    /// AutoMapper配置
    /// </summary>
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            //CreateMap<PersonDto, Person>();
        }
    }

    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {

        }
    }


}