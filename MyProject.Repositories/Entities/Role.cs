﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class Roles
    {
        #region data members
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        #endregion
        public Roles()
        {

        }
        public Roles(int id, string description, string name)
        {
            Id = id;
            Description = description;
            Name = name;
        }
    }
}
