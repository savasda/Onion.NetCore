using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Models;
using Infrastucture.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using I = Infrastucture.Interfaces.Models;

namespace Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IContextFactory _contextFactory;

        public UserService(IMapper mapper, IContextFactory contextFactory)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
        }

       
        public async Task<IList<User>> GetAllAsync()
        {
            using (var context = _contextFactory.GetDefaultContext())
            {
                var query = context.User.AsQueryable();

                var users = await query.ToListAsync().ConfigureAwait(false);

                return users.Select(item =>
                {
                    var entity = _mapper.Map<User>(item);
                    return entity;

                }).ToList();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = _contextFactory.GetDefaultContext())
            {
                var user = await context
                                 .User
                                 .FirstOrDefaultAsync(_ => _.Id.Equals(id))
                                 .ConfigureAwait(false);

                if (user == null) return;

                await Task.Run(() => context
                                        .User
                                        .Remove(user))
                                        .ConfigureAwait(false);

                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(int id)
        {
            using (var context = _contextFactory.GetDefaultContext())
            {
                var user = await context
                    .User
                    .FirstOrDefaultAsync(el => el.Id.Equals(id))
                    .ConfigureAwait(false);

                var entity = _mapper.Map<User>(user);
                return entity;
            }
        }

        public Task<IList<User>> GetPagedAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int? id, User item)
        {
            using (var context = _contextFactory.GetDefaultContext())
            {
                I.User findedUser = new I.User();

                if(id != null)
                {
                    findedUser = await context.User
                        .FirstOrDefaultAsync(el => el.Id.Equals(id))
                        .ConfigureAwait(false);

                    _mapper.Map(item, findedUser);
                } else
                {
                    _mapper.Map(item, findedUser);
                    await context.User.AddAsync(findedUser).ConfigureAwait(false);
                }
            }
        }

    }
}
