using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        List<Permission> GetAll();
        Permission GetById(int Id);
        Permission Add(int id, string name, string description);
        Permission Update(Permission c);
        void Delete(int id);
    }
}
