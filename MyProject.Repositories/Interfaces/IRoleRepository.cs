using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        List<Roles> GetAll();
        Roles GetById(int Id);
        Roles Add(int id, string name, string description);
        Roles Update(Roles c);
        void Delete(int id);
    }
}
