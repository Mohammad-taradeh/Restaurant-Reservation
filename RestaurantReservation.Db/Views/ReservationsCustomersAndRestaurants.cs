using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Views;

public class ReservationsCustomersAndRestaurants
{
    public string ReservationID { get; set; }
    public string RestaurantID { get; set; }
    public string RestaurantName { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
}
