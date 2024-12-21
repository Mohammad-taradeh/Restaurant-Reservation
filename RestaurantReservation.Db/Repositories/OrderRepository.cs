using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;
using System.Linq;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
{
    private RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if(order == null)
        {
            return;
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
    {
        return await _context.OrderItems
                        .Where(o => o.Order.ReservationId == reservationId)
                        .Select(o => o.Item)
                        .ToListAsync();
    }
    public async Task<List<OrderItem>> ListOrdersAndMenuItems(int reservationId)
    {
         return await _context.OrderItems
           .Where(o => o.Order.ReservationId == reservationId)
           .Include(o => o.Order)
           .ThenInclude(o => o.OrderItems)
           .ThenInclude(x => x.Item)
           .AsSplitQuery()
           .ToListAsync();
    }

    public async Task<Order> Save(Order order)
    {
        var addedOrder = await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return addedOrder.Entity;
    }

    public async Task<Order> Update(Order order)
    {
        var updatedOrder = _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return updatedOrder.Entity;
    }
}
