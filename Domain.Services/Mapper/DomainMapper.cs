using AutoMapper;
using D = Domain.Interfaces.Models;
using I = Infrastucture.Interfaces.Models;

namespace Domain.Services.Mapper
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {
            CreateMap<D.Device, I.Device>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
            CreateMap<D.User, I.User>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
        }
    }
}
