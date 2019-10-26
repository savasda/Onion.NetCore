using Infrastucture.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services.Context
{
    public class ContextFactory : IContextFactory
    {

        private readonly IConfiguration _configuration;

        public ContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDefaultContext GetDefaultContext()
        {            
            var dbOptionsBuilder = new DbContextOptionsBuilder();
            dbOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"));
            return new DefaultContext(_configuration, dbOptionsBuilder.Options);
        }

        public void Dispose()
        {

        }
    }
}
