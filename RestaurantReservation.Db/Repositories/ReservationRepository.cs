using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : BaseRepository<Reservation>
{
    public ReservationRepository(RestaurantReservationDbContext context)
        : base(context)
    {
    }

    public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
    {
        return await _dbContext.Reservations.Where(res => res.CustomerId == customerId).ToListAsync();
    }
    
    
}
