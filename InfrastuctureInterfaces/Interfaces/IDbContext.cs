using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.Interfaces.Interfaces
{
    public interface IAppDbContext : IDisposable
    {

        void SaveChanges();

        EntityEntry Entry(object entry);
    }
}
