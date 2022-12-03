using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Repositories.Repositories
{
    public class ClaimRepository  :IClaimRepository
    {
        private readonly IContext _context;

        public ClaimRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Claim> AddAsync(int id, int roleId, int premissionId,EPolicy policy)
        {
            var added = _context.Claims.Add(new Claim { Id = id,  RoleId=roleId , PermissionId=premissionId,Policy=policy });
            await _context.SaveChangesAsync();
            return added.Entity;
        }       

        public async Task DeleteAsync(int id)
        {
            Claim c= _context.Claims.ToList<Claim>().Find(r => r.Id == id);
            _context.Claims.Remove(c);
            await _context.SaveChangesAsync();
        }

        public async Task<DbSet<Claim>> GetAllAsync()
        {
            await _context.SaveChangesAsync();
            return _context.Claims;
        }

        public async Task<Claim> GetByIdAsync(int Id)
        {
            await _context.SaveChangesAsync();

            return _context.Claims.ToList<Claim>().Find( r => r.Id == Id);
        }

        public async Task<Claim> UpdateAsync(Claim c)
        {
            
            _context.Claims.ToList<Claim>().Find(r => r.Id == c.Id).Policy = c.Policy;
            _context.Claims.ToList<Claim>().Find(r => r.Id == c.Id).RoleId = c.RoleId;
            _context.Claims.ToList<Claim>().Find(r => r.Id == c.Id).PermissionId = c.PermissionId;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
