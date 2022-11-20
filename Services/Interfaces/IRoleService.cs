using common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    interface IRoleService
    {
        List<RoleDTO> GetAll();
        RoleDTO GetById(int Id);
        RoleDTO Add(int id, string name, string description);
        RoleDTO Update(Roles c);
        void Delete(int id);
    }
}
