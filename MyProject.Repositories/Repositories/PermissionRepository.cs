using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Entities;


namespace MyProject.Repositories.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IContext _context;


        public PermissionRepository(IContext context)
        {
            _context = context;
        }

        public Permission Add(int id, string name, string description)
        {
            Permission r = new Permission(id, description, name);
            _context.Permissions.Add(r);
            return r;
        }

        public void Delete(int id)
        {
            _context.Permissions.Remove(_context.Permissions.Find(r => r.Id == id));
        }

        public List<Permission> GetAll()
        {
            return _context.Permissions;
        }

        public Permission GetById(int Id)
        {
            return _context.Permissions.Find(r => r.Id == Id);
        }

        public Permission Update(Permission c)
        {
            _context.Permissions.Find(r => r.Id == c.Id).Name = c.Name;
            _context.Permissions.Find(r => r.Id == c.Id).Description = c.Description;
            return c;
        }
    }
}
