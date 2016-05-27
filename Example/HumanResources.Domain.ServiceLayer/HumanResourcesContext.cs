using System.Data.Entity;
using HumanResources.Domain.Entities;

namespace HumanResources.Domain.ServiceLayer
{
    public class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext() : base("DBConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasKey(t => t.Id);
            modelBuilder.Entity<PersonnelDepartment>().HasKey(t => t.Id);
        }

        public DbSet<PersonnelDepartment> PersonnelDepartments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
