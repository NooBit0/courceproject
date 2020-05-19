using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models.Users;

namespace CourseProject.Models
{
    public class CourceProjectDbContext : DbContext
    {
        public CourceProjectDbContext()
            : base("CourceProjectDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CourceProjectDbContext>());
        }

        public DbSet<RentalPremises> RentalPremises { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Accountant> Accountants { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
