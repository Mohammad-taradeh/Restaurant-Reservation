using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : BaseRepository<Restaurant>
{
    public RestaurantRepository(RestaurantReservationDbContext context)
        : base(context)
    {
    }
}
