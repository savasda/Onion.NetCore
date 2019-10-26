using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Models;
using Infrastucture.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using I = Infrastucture.Interfaces.Models;

namespace Domain.Services.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IMapper _mapper;
        private readonly IContextFactory _contextFactory;

        public DeviceService(IMapper mapper, IContextFactory context)
        {
            _contextFactory = context;
            _mapper = mapper;
        }



        public async Task<IList<Device>> GetAllAsync()
        
        {

            using (var context = _contextFactory.GetDefaultContext())
            {
                var query = context.Device.AsQueryable();

                var devices = await query.ToListAsync().ConfigureAwait(false);

                return devices.Select(item =>
                {
                    var entity = _mapper.Map<Device>(item);
                    return entity;

                }).ToList();
            }
        }




        public async Task DeleteAsync(int id)
        {
            using (var context = _contextFactory.GetDefaultContext())
            {
                var device = await context
                                 .Device
                                 .FirstOrDefaultAsync(_ => _.Id.Equals(id))
                                 .ConfigureAwait(false);

                if (device == null) return;

                await Task.Run(() => context
                                        .Device
                                        .Remove(device))
                                        .ConfigureAwait(false);

                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        

        public Task<Device> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Device>> GetPagedAsync(int skip, int take)
        {
            using (var context = _contextFactory.GetDefaultContext())
            {
                var offset = (skip - 1) * take;
                var devices = await context.Device.Skip(offset).Take(take).ToListAsync().ConfigureAwait(false);

                return devices.Select(item =>
                {
                    var entity = _mapper.Map<Device>(item);
                    return entity;
                }).ToList();
            }
        }

        public async Task UpdateAsync(int? id, Device item)
        {
            using (var context = _contextFactory.GetDefaultContext())
            {
                I.Device choosenDevice = new I.Device();

                if(id != null)
                {
                    choosenDevice = await context
                        .Device
                        .FirstOrDefaultAsync(_ => _.Id.Equals(id))
                        .ConfigureAwait(false);

                    _mapper.Map(item, choosenDevice);

                } else
                {
                    _mapper.Map(item, choosenDevice);
                    await context.Device.AddAsync(choosenDevice).ConfigureAwait(false);
                }
            }
        }
    }
}
