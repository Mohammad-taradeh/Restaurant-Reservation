using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using System.Linq;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(RestaurantReservationDbContext context) 
        : base(context)
    {
    }
    public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
    {
        return await _dbContext.OrderItems
                        .Where(o => o.Order.ReservationId == reservationId)
                        .Select(o => o.Item)
                        .ToListAsync();
    }
    public async Task<List<OrderItem>> ListOrdersAndMenuItems(int reservationId)
    {
         return await _dbContext.OrderItems
           .Where(o => o.Order.ReservationId == reservationId)
           .Include(o => o.Order)
           .ThenInclude(o => o.OrderItems)
           .ThenInclude(x => x.Item)
           .AsSplitQuery()
           .ToListAsync();
    }
}
