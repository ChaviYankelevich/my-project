using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Entities;


namespace MyProject.Repositories.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly IContext _context;

        public ClaimRepository(IContext context)
        {
            _context = context;
        }

        public Claim Add(int id, int roleId, int premissionId,EPolicy policy)
        {
            Claim r = new Claim(id, roleId, premissionId, policy);
            _context.Claims.Add(r);
            return r;
        }       

        public void Delete(int id)
        {
            _context.Claims.Remove(_context.Claims.Find(r => r.Id == id));
        }

        public List<Claim> GetAll()
        {
            return _context.Claims;
        }

        public Claim GetById(int Id)
        {
            return _context.Claims.Find(r => r.Id == Id);
        }

        public Claim Update(Claim c)
        {
            _context.Claims.Find(r => r.Id == c.Id).Policy = c.Policy;
            _context.Claims.Find(r => r.Id == c.Id).RoleId = c.RoleId;
            _context.Claims.Find(r => r.Id == c.Id).PermissionId = c.PermissionId;
            return c;
        }
    }
}
