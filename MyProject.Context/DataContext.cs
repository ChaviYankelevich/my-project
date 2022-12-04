using MyProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MyProject.Repositories.Entities;
using System.Threading.Tasks;

namespace MyProject.Context
{
   public class DataContext : DbContext, IContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get ; set ; }
        public DbSet<Claim> Claims { get; set ; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDBName;Trusted_Connection=True;");
        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
