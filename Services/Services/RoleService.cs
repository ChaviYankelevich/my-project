using AutoMapper;
using common.DTOs;
using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoleService:IRoleService
    {

        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<RoleDTO> AddAsync(int id, string name, string description)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.AddAsync(id,name,description));
        }

        public async Task DeleteAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }

        public async Task<DbSet<RoleDTO>> GetAllAsync()
        {
            return _mapper.Map<DbSet<RoleDTO>>(await _roleRepository.GetAllAsync());
        }

        public async Task<RoleDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.GetByIdAsync(id));
        }

        public async Task<RoleDTO> UpdateAsync(Roles c)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.UpdateAsync(c));
        }
    }
}
