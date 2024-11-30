using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : BaseRepository<MenuItem>
{
    
    public MenuItemRepository(RestaurantReservationDbContext context)
        :base(context)
    {
        
    }
    
}
