using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }
    public async Task Delete(int id)
    {
        var orderItem = await _context.OrderItems.FindAsync(id);
        if (orderItem == null)
        {
            return;
        }
        _context.OrderItems.Remove(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task<OrderItem> Save(OrderItem orderItem)
    {
        var savedOrderItem = await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
        return savedOrderItem.Entity;
    }

    public async Task<OrderItem> Update(OrderItem orderItem)
    {
        var updatedOrderItem = _context.OrderItems.Update(orderItem);
        await _context.SaveChangesAsync();
        return updatedOrderItem.Entity;
    }
}
