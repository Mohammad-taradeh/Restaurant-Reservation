using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Configurations;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(EmployeeConfiguration))]
public class Employee
{
    public int EmployeeID { get; set; }
    [Required]
    public int RestaurantId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Positions Position { get; set; }

    public string Email {  get; set; }
    public string PhoneNumber { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public Restaurant Restaurant { get; set; }
}