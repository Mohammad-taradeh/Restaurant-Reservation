using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface IReservationRepository
{
    public Task<Reservation> Save(Reservation reservation);
    public Task<Reservation> Update(Reservation reservation);
    public Task Delete(int id);
    Task<List<Reservation>> GetReservationsByCustomer(int customerId);
}
