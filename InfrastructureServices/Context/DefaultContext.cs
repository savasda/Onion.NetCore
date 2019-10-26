
using Infrastructure.Services.Maps;
using Infrastucture.Interfaces.Interfaces;
using Infrastucture.Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Infrastructure.Services.Context
{
    public class DefaultContext : DbContext, IDefaultContext

    {
        private IConfiguration _configuration;

        public DefaultContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public DbSet<Device> Device { get; set; }
        public DbSet<User> User { get; set; }

        void IAppDbContext.SaveChanges()
        {
            throw new System.NotImplementedException();
        }

      
    }
}
