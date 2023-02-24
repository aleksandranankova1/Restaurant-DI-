using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Data
{
    public class RestaurantDbContext : IdentityDbContext<Client>
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bevarage> Drinks { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TypeBevarage> TypeDrinks { get; set; }
        public DbSet<TypeMeal> TypeMeals { get; set; }
    }
}