using Microsoft.EntityFrameworkCore;
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
        Task<DbSet<Permission>> GetAllAsync();
        Task<Permission> GetByIdAsync(int Id);
        Task<Permission> AddAsyncc(int id, string name, string description);
        Task<Permission> UpdateAsync(Permission c);
        Task DeleteAsync(int id);
    }
}
