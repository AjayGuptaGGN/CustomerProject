
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class AppDBContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            this.Database.EnsureCreated();
            this.Database.SetCommandTimeout(15000); 
        } 
         
        protected void OnModelCreateing(ModelBuilder  modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>().Property(c=>c.CustomerId).ValueGeneratedOnAdd();
        }
    }
}
