using BulkyWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category() { Id=1,Name="Action",DisplayOrder=1},
        //         new Category() { Id = 2, Name = "SciFi", DisplayOrder = 2 },
        //          new Category() { Id = 3, Name = "History", DisplayOrder = 3 }
                   
        //        );
        //}
    }
}
