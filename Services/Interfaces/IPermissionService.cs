using common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    interface IPermissionService
    {
        List<PermissionDTO> GetAll();
        PermissionDTO GetById(int Id);
        PermissionDTO Add(int id, string name, string description);
        PermissionDTO Update(Permission c);
        void Delete(int id);
    }
}
