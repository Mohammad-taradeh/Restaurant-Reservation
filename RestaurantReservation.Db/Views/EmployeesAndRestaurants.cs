using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Configurations;

namespace RestaurantReservation.Db.Views;
[EntityTypeConfiguration(typeof(EmployeeAndRestaurentsConfigurations))]
public class EmployeesAndRestaurants
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string Position { get; set; }
    public int RestaurantId { get; set; }
    public string Restaurant { get; set; }

}
