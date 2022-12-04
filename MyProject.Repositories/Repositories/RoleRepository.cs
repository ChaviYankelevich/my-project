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
   public  class RoleRepository: IRoleRepository
    {
        private readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Role> AddAsync(int id, string name, string description)
        {
            var added = _context.Roles.Add(new Role { Id = id, Name = name, Description = description });
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            Role r = _context.Roles.ToList<Role>().Find(r => r.Id == id);
            _context.Roles.Remove(r);
            await _context.SaveChangesAsync();

        }

        public async Task<DbSet<Role>> GetAllAsync()
        {
            await _context.SaveChangesAsync();
            return _context.Roles;
        }

        public async Task<Role> GetByIdAsync(int Id)
        {
            await _context.SaveChangesAsync();
            return _context.Roles.ToList<Role>().Find(r => r.Id == Id);
        }

        public async Task<Role> UpdateAsync(Role c)
        {
            _context.Roles.ToList<Role>().Find(r => r.Id == c.Id).Name = c.Name;
            _context.Roles.ToList<Role>().Find(r => r.Id == c.Id).Description = c.Description;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
