using common.DTOs;
using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = MyProject.Repositories.Entities.Claim;

namespace Services.Interfaces
{
    public interface IClaimService
    {
        Task<DbSet<ClaimDTO>> GetAllAsync();
        Task<ClaimDTO> GetByIdAsync(int Id);
        Task<ClaimDTO> AddAsync(int id, int roleId, int premissionId, EPolicy policy);
        Task<ClaimDTO> UpdateAsync(Claim c);
        Task DeleteAsync(int id);
    }
}
