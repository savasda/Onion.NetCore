using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using MainApi.Interfaces;
using MainApi.Models;
using Microsoft.AspNetCore.Mvc;
using D = Domain.Interfaces.Models;

namespace MainApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IBaseController<UserViewModel>
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _userService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var entity = await _userService.GetAllAsync();

            return entity.Select(item =>
            {
                var users = _mapper.Map<UserViewModel>(item);
                return users;

            }).ToList();

        }


        [HttpDelete("{id:int}")]
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public async Task PostAsync([FromBody] UserViewModel entity)
        {
            try
            {
                var mappedUser = _mapper.Map<D.User>(entity);
                await _userService.UpdateAsync(null, mappedUser);
            } catch {
               
            }

        }

        [HttpGet("{id:int}")]
        Task<UserViewModel> IBaseController<UserViewModel>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public Task PutAsync(int id, [FromBody] UserViewModel entity)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{currentPage:int}/{onPage:int}")]
        Task<IList<UserViewModel>> IBaseController<UserViewModel>.GetPagedAsync(int currentPage, int onPage)
        {
            throw new NotImplementedException();
        }
    }
}