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
            Role r = new Role(id);          
            var added = _context.Claims.Add(new Claim { Id = id,Role=r, Permission=new Permission(id), Policy = policy });
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
            _context.Claims.ToList<Claim>().Find(r => r.Id == c.Id).Role.Id = c.Role.Id;
            _context.Claims.ToList<Claim>().Find(r => r.Id == c.Id).Permission.Id = c.Permission.Id;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
