using AutoMapper;
using common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleDTO>()
              //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ReverseMap();
            CreateMap<Claim, ClaimDTO>()
             /*.ForMember/*//**(dest => dest.Description, opt => opt.MapFrom(src => src.Description))*/
             .ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
        }
    }
}
