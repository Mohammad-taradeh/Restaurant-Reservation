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
    public DbSet<EmployeesAndRestaurants>  EmployeesAndRestaurants { get; set; }
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
        modelBuilder.Entity<EmployeesAndRestaurants>()
            .HasNoKey()
            .ToView(nameof(EmployeesAndRestaurants));
        
        modelBuilder.Entity<ReservationsCustomersAndRestaurants>()
            .HasNoKey()
            .ToView(nameof(ReservationsCustomersAndRestaurants));

        modelBuilder.Entity<Employee>()
            .Property(x => x.Position)
            .HasConversion<PositionConvertor>();

        var restausants = new List<Restaurant>()
        {
            new Restaurant {RestaurantId = 1, Name = "Zuwar", Address = "Hebron", OpeningHoures = "24/7", PhoneNumber = "0593929588" }
        };
        modelBuilder.Entity<Restaurant>().HasData(restausants);


        var menueItems = new List<MenuItem>()
        {
            new MenuItem {MenuItemId = 1, Name = "Fries", Description = "Frensh fries", Price = 5, RestaurantId = 1},
            new MenuItem {MenuItemId = 2, Name = "Cordon Bleu", Description = "Cheken with cheese", Price = 25, RestaurantId = 1},
            new MenuItem {MenuItemId = 3, Name = "Crispy", Description = "Crispy fried checken", Price = 30, RestaurantId = 1},
            new MenuItem {MenuItemId = 4, Name = "Butter Chicken", Description = "Chicken coocked in butter", Price = 35, RestaurantId = 1},
        };
        modelBuilder.Entity<MenuItem>().HasData(menueItems);


        var tables = new List<Table>()
        {
            new Table {TableId = 1, Capacity = 2, RestaurantId = 1 },
            new Table {TableId = 2, Capacity = 5, RestaurantId = 1 },
            new Table {TableId = 3, Capacity = 7, RestaurantId = 1 },
            new Table {TableId = 4, Capacity = 10, RestaurantId = 1 }
        };
        modelBuilder.Entity<Table>().HasData(tables);

        var employees = new List<Employee>()
        { new Employee {EmployeeID = 1, FirstName = "Sabah", LastName = "Ba'raa", Position = Positions.Manager, RestaurantId = 1 },
            new Employee {EmployeeID = 2, FirstName = "Mostafa", LastName = "Tahboub", Position = Positions.Employee, RestaurantId = 1},
            new Employee {EmployeeID = 3, FirstName = "Mohammad", LastName = "Taradeh", Position = Positions.Owner, RestaurantId = 1 },
            new Employee {EmployeeID = 4, FirstName = "Ahmad", LastName = "Jabari", Position = Positions.Employee, RestaurantId = 1 },
            new Employee {EmployeeID = 5, FirstName = "Ibrahim", LastName = "Khamaisa", Position = Positions.Employee, RestaurantId = 1 }
        };
        modelBuilder.Entity<Employee>().HasData(employees);

        var customers = new List<Customer>()
        {
            new Customer {CustomerId = 1, FirstName ="Mohammad", LastName = "Ahmad", Email = "201160@ppu.edu.ps", PhoneNumber = "0569726909"},
            new Customer {CustomerId = 2, FirstName ="Amjad", LastName = "Khanaysa", Email = "201116@ppu.edu.ps", PhoneNumber = "0569726909"},
            new Customer {CustomerId = 3, FirstName ="Ahmad", LastName = "Ameer", Email = "55226@ppu.edu.ps", PhoneNumber = "0569726909"},
        };
        modelBuilder.Entity<Customer>().HasData(customers);

        var reservation = new List<Reservation> 
        {
            new Reservation { ReservationId = 1, CustomerId = 1, PartySize = 3, RestaurantId = 1, TableId = 2, Date = new DateTime(2024, 5, 1) },
            new Reservation { ReservationId = 2, CustomerId = 1, PartySize = 2, RestaurantId = 1, TableId = 1, Date = new DateTime(2024, 2, 1) },
            new Reservation { ReservationId = 3, CustomerId = 2, PartySize = 5, RestaurantId = 1, TableId = 3, Date = new DateTime(2024, 6, 1) },
            new Reservation { ReservationId = 4, CustomerId = 3, PartySize = 10, RestaurantId = 1, TableId = 4, Date = new DateTime(2024, 5, 11) },
            new Reservation { ReservationId = 5, CustomerId = 2, PartySize = 7, RestaurantId = 1, TableId = 1, Date = new DateTime(2024, 5, 21) },
        };
        modelBuilder.Entity<Reservation>().HasData(reservation);

        var orders = new List<Order>()
        {
            new Order { OrderId = 1, EmployeeId = 1, OrderDate = new DateTime(2024, 5, 1), TotalPrice = 100, ReservationId = 1 },
            new Order { OrderId = 2, EmployeeId = 2, OrderDate = new DateTime(2024, 2, 1), TotalPrice = 240, ReservationId = 2 },
            new Order { OrderId = 3, EmployeeId = 1, OrderDate = new DateTime(2024, 6, 1), TotalPrice = 1230, ReservationId = 3 },
            new Order { OrderId = 4, EmployeeId = 2, OrderDate = new DateTime(2024, 5, 11), TotalPrice = 50, ReservationId = 4 },
            new Order { OrderId = 5, EmployeeId = 4, OrderDate = new DateTime(2024, 5, 21), TotalPrice = 1000, ReservationId = 5 },
        };
        modelBuilder.Entity<Order>().HasData(orders);

        var orderItems = new List<OrderItem>()
        {
            new OrderItem {OrderItemId = 1, OrderId = 1,  ItemId= 1, Quantity = 2},
            new OrderItem {OrderItemId = 4, OrderId = 1,  ItemId= 2, Quantity = 1},
            new OrderItem {OrderItemId = 2, OrderId = 1,  ItemId= 3, Quantity = 4},
            new OrderItem {OrderItemId = 3, OrderId = 1,  ItemId= 3, Quantity = 6},
            new OrderItem {OrderItemId = 5, OrderId = 1,  ItemId= 4, Quantity = 1},
        };
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
    }
    public override void Dispose()
    {
        _writer.Dispose();
        base.Dispose();
    }
}
