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
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimController(IClaimRepository claimRepository)
=>
            _claimRepository = claimRepository;


        [HttpGet]
        public List<Claim> Get()
        {
            return _claimRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Claim Get(int id)
        {
            return _claimRepository.GetById(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => _claimRepository.Delete(id);
        [HttpPost]
        public void Post(int id, int roleId,int permitionId, EPolicy policy) => _claimRepository.Add(id, roleId,permitionId,policy);
        [HttpPut("{id}")]
        public void Put(int id, int roleId, int permitionId, EPolicy policy) => _claimRepository.Update(new Claim(id, roleId, permitionId, policy));
    }
}
