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
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
=>
            _claimService = claimService;


        [HttpGet]
        public Task<DbSet<ClaimDTO>> Get()
        {
            
            return _claimService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public Task<ClaimDTO> Get(int id)
        {
            return _claimService.GetByIdAsync(id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id) =>await _claimService.DeleteAsync(id);
        [HttpPost]
        public async Task Post(int id, int roleId,int permitionId, EPolicy policy) =>await _claimService.AddAsync(id, roleId,permitionId,policy);
        [HttpPut("{id}")]
        public async Task Put(int id, int roleId, int permitionId, EPolicy policy) =>await _claimService.UpdateAsync(new Claim(id, roleId, permitionId, policy));
    }
}
