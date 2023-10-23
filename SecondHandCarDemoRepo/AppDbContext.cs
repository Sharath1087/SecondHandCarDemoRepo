using Microsoft.EntityFrameworkCore;
using SecondHandCarDemoRepo.Models;

namespace SecondHandCarDemoRepo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Brand = "Maruti Suzuki", Model = "Swift", Kilometer = 13450, Price = 350000},
                new Car { Id = 2, Brand = "Honda", Model = "City", Kilometer = 23987, Price = 750000},
                new Car { Id = 3, Brand = "Mahindra", Model = "Thar", Kilometer = 43006, Price = 1000000}
                );
        }
    }
}
