using AutoMapper;
using common.DTOs;
using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = MyProject.Repositories.Entities.Claim;

namespace Services.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;

        public ClaimService(IClaimRepository claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }
        public async Task<ClaimDTO> AddAsync(int id, int roleId, int premissionId, EPolicy policy)
        {
            return _mapper.Map<ClaimDTO>(await _claimRepository.AddAsync(id, roleId, premissionId, policy));
        }
        public async Task DeleteAsync(int id)
        {
          await _claimRepository.DeleteAsync(id);
        }

        public async Task<DbSet<ClaimDTO>> GetAllAsync()
        {
            return _mapper.Map<DbSet<ClaimDTO>>(await _claimRepository.GetAllAsync());
        }

        public async Task<ClaimDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ClaimDTO>(await _claimRepository.GetByIdAsync(id));
        }

        public async Task<ClaimDTO> UpdateAsync(Claim c)
        {
            return _mapper.Map<ClaimDTO>(await _claimRepository.UpdateAsync(c));
        }
    }
}
