namespace RestaurantReservation.Db.Models;

public class Reservation
{
    public int ReservationId { get; set; }

    public int CustomerId { get; set; }

    public int RestaurantId { get; set; }

    public int? TableId { get; set; }

    public DateTime Date { get; set; }

    public int PartySize { get; set; }

    public Customer Customer { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();

    public Restaurant Restaurant { get; set; }

    public Table Table { get; set; }
}