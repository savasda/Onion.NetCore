using AutoMapper;
using D = Domain.Interfaces.Models;
using MainApi.Models;

namespace MainApi.Mapper
{
    public class MainApiMap : Profile
    {
        public MainApiMap()
        {
            CreateMap<DeviceViewModel, D.Device>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
            CreateMap<UserViewModel, D.User>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();

        }
    }
}
