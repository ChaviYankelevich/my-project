using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IClaimRepository
    {
       Task<DbSet<Claim>> GetAllAsync();
       Task<Claim> GetByIdAsync(int Id);
       Task<Claim> AddAsync(int id, int roleId, int premissionId, EPolicy policy);
       Task<Claim> UpdateAsync(Claim c);
       Task DeleteAsync(int id);
    }
}
