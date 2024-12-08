using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Configurations;

namespace RestaurantReservation.Db.Views;
[EntityTypeConfiguration(typeof(ReservationsCustomersAndRestaurentsConfiguration))]
public class ReservationsCustomersAndRestaurants
{
    public string ReservationID { get; set; }
    public string RestaurantID { get; set; }
    public string RestaurantName { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
}
