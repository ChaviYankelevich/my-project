using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Entities;


namespace MyProject.Repositories.Repositories
{
   public  class RoleRepository : IRoleRepository
    {
        private readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }

        public Roles Add(int id, string name, string description)
        {
            Roles r = new Roles(id, description, name);
            _context.Roles.Add(r);
            return r;
        }

        public void Delete(int id)
        {
            _context.Roles.Remove(_context.Roles.Find(r => r.Id == id));
        }

        public List<Roles> GetAll()
        {
            return _context.Roles;
        }

        public Roles GetById(int Id)
        {
            return _context.Roles.Find(r => r.Id == Id);
        }

        public Roles Update(Roles c)
        {
            _context.Roles.Find(r => r.Id == c.Id).Name = c.Name;
            _context.Roles.Find(r => r.Id == c.Id).Description = c.Description;
            return c;
        }
    }
}
