using common.DTOs;
using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
   public interface IRoleService
    {
        Task<DbSet<RoleDTO>> GetAllAsync();
        Task<RoleDTO> GetByIdAsync(int Id);
        Task<RoleDTO> AddAsync(int id, string name, string description);
        Task<RoleDTO> UpdateAsync(Role c);
        Task DeleteAsync(int id);
    }
}
