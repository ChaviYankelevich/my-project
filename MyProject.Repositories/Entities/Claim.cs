using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public enum EPolicy { Allow, Deny }

    public class Claim
    {
        public int Id { get; set; }

        public Role Role { get; set; }

        public Permission Permission { get; set; }

        public EPolicy Policy { get; set; }
        public Claim()
        {

        }

        public Claim(int id, int roleId, int permissionId, EPolicy policy)
        {
            Id = id;
            Role.Id = roleId;
            Permission.Id = permissionId;
            Policy = policy;
        }

    }
}
