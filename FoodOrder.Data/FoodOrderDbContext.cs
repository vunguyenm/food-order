using FoodOrder.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data
{
    public class FoodOrderDbContext : DbContext
    {
        public FoodOrderDbContext(DbContextOptions<FoodOrderDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}