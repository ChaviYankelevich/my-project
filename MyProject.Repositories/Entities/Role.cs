using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class Role
    {
        #region data members
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        #endregion
        public Role()
        {

        }
        public Role(int id)
        {
            Id = id;
        }
        public Role(int id, string description, string name)
        {
            Id = id;
            Description = description;
            Name = name;
        }
    }
}
