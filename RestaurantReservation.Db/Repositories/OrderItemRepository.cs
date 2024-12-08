using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem>
{
    public OrderItemRepository(RestaurantReservationDbContext context)
        : base(context)
    {
    }
    
}
