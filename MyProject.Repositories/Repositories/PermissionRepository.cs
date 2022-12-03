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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IContext _context;


        public PermissionRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Permission> AddAsyncc(int id, string name, string description)
        {
            Permission r = new Permission(id, description, name);
            _context.Permissions.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task DeleteAsync(int id)
        {
            Permission p= _context.Permissions.ToList<Permission>().Find(r => r.Id == id);
            _context.Permissions.Remove(p);
            await _context.SaveChangesAsync();
        }

        public async Task<DbSet<Permission>> GetAllAsync()
        {
            await _context.SaveChangesAsync();
            return _context.Permissions;
        }

        public async Task<Permission> GetByIdAsync(int Id)
        {
            await _context.SaveChangesAsync();
            return _context.Permissions.ToList<Permission>().Find(r => r.Id == Id);
        }

        public async Task< Permission> UpdateAsync(Permission c)
        {
            _context.Permissions.ToList<Permission>().Find(r => r.Id == c.Id).Name = c.Name;
            _context.Permissions.ToList<Permission>().Find(r => r.Id == c.Id).Description = c.Description;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
