using BackTask.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackTask.Database
{
    public class TaskDbContext : DbContext
    {

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }

  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>()
            //    .HasOne(c => c.Country)
            //    .WithMany(c => c.Cities)
            //    .HasForeignKey(c => c.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Customer>()
            //    .HasOne(c => c.Country)
            //    .WithMany()
            //    .HasForeignKey(c => c.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<Customer>()
            //    .HasOne(c => c.City)  
            //    .WithMany()  
            //    .HasForeignKey(c => c.CityId) 
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
             .HasOne(c => c.Country)
             .WithMany()
             .HasForeignKey(c => c.CountryId)
             .OnDelete(DeleteBehavior.NoAction); 



        }
    }
}
