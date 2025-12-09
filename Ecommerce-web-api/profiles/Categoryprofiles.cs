namespace asp_net_ecommerce_web_api.profiles
{
    public class Categoryprofiles : AutoMapper.Profile
    {
        public Categoryprofiles()
        {
            CreateMap<Models.Category, DTOs.CategoryReadDtos>();
            CreateMap<DTOs.CategoryCreateDtos, Models.Category>();
        }
    }
}