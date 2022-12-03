using common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Mock;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
    

        [HttpGet]
        public Task<DbSet<PermissionDTO>> Get()
        {
            return _permissionService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public Task<PermissionDTO> Get(int id)
        {
            return _permissionService.GetByIdAsync(id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id) =>await _permissionService.DeleteAsync(id);
        [HttpPost]
        public async Task Post(int id, string name, string description) =>await _permissionService.AddAsync(id, name, description);
        [HttpPut("{id}")]
        public async Task Put(int id, string name, string description) =>await _permissionService.UpdateAsync(new Permission(id, name, description));
    }
}
