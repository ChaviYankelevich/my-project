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
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public List<Roles> Get()
        {
            return _roleRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Roles Get(int id)
        {
            return _roleRepository.GetById(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => _roleRepository.Delete(id);
        [HttpPost]
        public void Post(int id,string name,string description) => _roleRepository.Add(id, name, description);
        [HttpPut("{id}")]
        public void Put(int id, string name, string description) => _roleRepository.Update(new Roles(id, name, description));
    }
}
