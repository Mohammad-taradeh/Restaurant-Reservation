using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : BaseRepository<Customer>
{
    public CustomerRepository(RestaurantReservationDbContext context)
        : base(context)
    {
    }
}
