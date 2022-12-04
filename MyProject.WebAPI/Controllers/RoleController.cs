using common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Mock;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public Task<DbSet<RoleDTO>> Get()
        {
            return _roleService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public Task<RoleDTO> Get(int id)
        {
            return _roleService.GetByIdAsync(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => _roleService.DeleteAsync(id);
        [HttpPost]
        public void Post(int id,string name,string description) => _roleService.AddAsync(id, name, description);
        [HttpPut("{id}")]
        public void Put(int id, string name, string description) => _roleService.UpdateAsync(new Role(id, name, description));
    }
}
