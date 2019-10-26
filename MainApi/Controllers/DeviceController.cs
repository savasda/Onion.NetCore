using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using MainApi.Interfaces;
using MainApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;



namespace MainApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase, IBaseController<DeviceViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDeviceService _deviceService;
        private readonly IConfiguration _configuration;

        public DeviceController(IMapper mapper, IDeviceService deviceService, IConfiguration configuration)
        {
            _configuration = configuration;
            _mapper = mapper;
            _deviceService = deviceService;
        }


        [HttpGet]
        public async Task<IEnumerable<DeviceViewModel>> GetAllAsync()
        
        {
            var devices = await _deviceService.GetAllAsync();

            return devices.Select(el =>
            {
                var entity = _mapper.Map<DeviceViewModel>(el);
                return entity;
            }).ToList();
        }

        [HttpDelete("{id:int}")]
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        [HttpGet("{id:int}")]
        public Task<DeviceViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{currentPage:int}/{onPage:int}")]
        public Task<IList<DeviceViewModel>> GetPagedAsync(int currentPage, int onPage)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task PostAsync([FromBody] DeviceViewModel entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public Task PutAsync(int id, [FromBody] DeviceViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}