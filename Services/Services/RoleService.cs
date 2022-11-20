using AutoMapper;
using common.DTOs;
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
        public RoleDTO Add(int id, string name, string description)
        {
            return _mapper.Map<RoleDTO>(_roleRepository.Add(id,name,description));
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

        public List<RoleDTO> GetAll()
        {
            return _mapper.Map<List<RoleDTO>>(_roleRepository.GetAll());
        }

        public RoleDTO GetById(int id)
        {
            return _mapper.Map<RoleDTO>(_roleRepository.GetById(id));
        }

        public RoleDTO Update(Roles c)
        {
            return _mapper.Map<RoleDTO>(_roleRepository.Update(c));
        }
    }
}
