using Microsoft.EntityFrameworkCore;
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
        Task<DbSet<Roles>> GetAllAsync();
        Task<Roles> GetByIdAsync(int Id);
        Task<Roles> AddAsync(int id, string name, string description);
        Task<Roles> UpdateAsync(Roles c);
        Task DeleteAsync(int id);
    }
}
