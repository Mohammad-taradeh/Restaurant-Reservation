using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            return;
        }
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
    {
        return await _context.Reservations.Where(res => res.CustomerId == customerId).ToListAsync();
    }

    public async Task<Reservation> Save(Reservation reservation)
    {
        var savedReservation = await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
        return savedReservation.Entity;
    }

    public async Task<Reservation> Update(Reservation reservation)
    {
        var updatedReservation = _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
        return updatedReservation.Entity;
    }
}
