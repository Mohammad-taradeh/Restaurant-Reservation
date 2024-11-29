namespace RestaurantReservation.Db.Models;

public class Employee
{
    public int EmployeeID { get; set; }

    public int RestaurantId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Positions Position { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public Restaurant Restaurant { get; set; }
}