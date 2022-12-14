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
    public class PermissionService : Interfaces.IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository; ;
            _mapper = mapper;
        }
        public async Task<PermissionDTO> AddAsync(int id, string name, string description)
        {
            return _mapper.Map<PermissionDTO>(await _permissionRepository.AddAsyncc(id, name, description));
        }

        public async Task DeleteAsync(int id)
        {
           await _permissionRepository.DeleteAsync(id);
        }

        public async Task<DbSet<PermissionDTO>> GetAllAsync()
        {
            return _mapper.Map<DbSet<PermissionDTO>>(await _permissionRepository.GetAllAsync());
        }

        public async Task<PermissionDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<PermissionDTO>(await _permissionRepository.GetByIdAsync(id));
        }

        public async Task<PermissionDTO> UpdateAsync(Permission c)
        {
            return _mapper.Map<PermissionDTO>(await _permissionRepository.UpdateAsync(c));
        }
    }
}
