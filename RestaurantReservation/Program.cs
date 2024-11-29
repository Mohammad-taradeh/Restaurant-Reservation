using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
namespace RestaurantReservation;
public static class Program
{
    private static RestaurantReservationDbContext _context = new();
    
    
    
    
    
    public static void Main(string[] args)
    {
        var empRepo = new OrderRepository(_context);
        var result = empRepo.ListOrdersAndMenuItems(1);
        foreach(var menuItem in result)
        {
            Console.WriteLine(menuItem.Order.TotalPrice);
            Console.WriteLine(menuItem.Item.Name);
        }
        //empRepo.Create(new Employee() { FirstName = "123", LastName = "123", RestaurantId = 1 });
    }

}
