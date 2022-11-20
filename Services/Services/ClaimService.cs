using AutoMapper;
using common.DTOs;
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
        public ClaimDTO Add(int id, int roleId, int premissionId, EPolicy policy)
        {
            return _mapper.Map<ClaimDTO>(_claimRepository.Add(id, roleId, premissionId, policy));
        }
        public void Delete(int id)
        {
           _claimRepository.Delete(id);
        }

        public List<ClaimDTO> GetAll()
        {
            return _mapper.Map<List<ClaimDTO>>(_claimRepository.GetAll());
        }

        public ClaimDTO GetById(int id)
        {
            return _mapper.Map<ClaimDTO>(_claimRepository.GetById(id));
        }

        public ClaimDTO Update(Claim c)
        {
            return _mapper.Map<ClaimDTO>(_claimRepository.Update(c));
        }
    }
}
