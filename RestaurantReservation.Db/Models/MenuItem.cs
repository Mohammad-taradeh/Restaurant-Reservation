namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    public int MenuItemId { get; set; }

    public int RestaurantId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public Restaurant Restaurant { get; set; }
}