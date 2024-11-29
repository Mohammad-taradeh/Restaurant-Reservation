using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    private StreamWriter _writer = new ("EF Core Log.txt", append: true);
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
           
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //   .SetBasePath(Directory.GetCurrentDirectory())
            //   .AddJsonFile("appsettings.json")
            //   .Build();
            //var connectionString = configuration.GetConnectionString("RestaurantReservationDb");
            optionsBuilder.UseSqlServer("Data Source=Mohammad;Initial Catalog=RestaurantReservationCore;Integrated Security=True;Encrypt=False;Trust Server Certificate=True").LogTo(_writer.WriteLine,
                new[] {DbLoggerCategory.Database.Command.Name},
                LogLevel.Information).EnableSensitiveDataLogging();
        }

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
           .HasMany(e => e.Orders)
           .WithOne(o => o.Reservation)
           .HasForeignKey(o => o.ReservationId)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Table>()
            .HasMany(e => e.Reservations)
            .WithOne(r => r.Table)
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        //var customers = new List<Customer>()
        //{ 
        //    new Customer(){CustomerId = 1, FirstName = "Mohammad", LastName = "Taradeh", Email = "201160@ppu.edu.ps", PhoneNumber = "+970569726909"}
        //};

        //modelBuilder.Entity<Customer>().HasData(customers);


        modelBuilder.Entity<Employee>()
            .Property(x => x.Position)
            .HasConversion<PositionConvertor>();
    }
    public override void Dispose()
    {
        _writer.Dispose();
        base.Dispose();
    }
}
