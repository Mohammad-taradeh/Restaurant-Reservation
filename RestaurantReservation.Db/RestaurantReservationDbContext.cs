using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Views;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    private StreamWriter _writer = new("EF Core Log.txt", append: true);
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<EmployeesAndRestaurants> EmployeesAndRestaurants { get; set; }
    public DbSet<ReservationsCustomersAndRestaurants> ReservationsCustomersAndRestaurants { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder
                .UseSqlServer("Data Source=Mohammad;Initial Catalog=RestaurantReservationCore;Integrated Security=True;Encrypt=False;Trust Server Certificate=True").LogTo(_writer.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information).EnableSensitiveDataLogging();
        }

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //Seeding the database
        SeedingDatabase.Seed(modelBuilder);
    }
    public override void Dispose()
    {
        _writer.Dispose();
        base.Dispose();
    }
}
