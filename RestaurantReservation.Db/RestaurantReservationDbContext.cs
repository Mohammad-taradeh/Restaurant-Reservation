using Microsoft.EntityFrameworkCore;
namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
