using Infrastucture.Interfaces.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastucture.Interfaces.Interfaces
{
    public interface IDefaultContext : IAppDbContext
    {
        DbSet<Device> Device { get; set; }
        DbSet<User> User { get; set; }


    }
}
