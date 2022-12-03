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
    interface IPermissionService
    {
        Task<DbSet<PermissionDTO>> GetAllAsync();
        Task<PermissionDTO> GetByIdAsync(int Id);
        Task<PermissionDTO> AddAsync(int id, string name, string description);
        Task<PermissionDTO> UpdateAsync(Permission c);
        Task DeleteAsync(int id);
    }
}
