using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Mock;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
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
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
    

        [HttpGet]
        public List<Permission> Get()
        {
            return _permissionRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Permission Get(int id)
        {
            return _permissionRepository.GetById(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => _permissionRepository.Delete(id);
        [HttpPost]
        public void Post(int id, string name, string description) => _permissionRepository.Add(id, name, description);
        [HttpPut("{id}")]
        public void Put(int id, string name, string description) => _permissionRepository.Update(new Permission(id, name, description));
    }
}
