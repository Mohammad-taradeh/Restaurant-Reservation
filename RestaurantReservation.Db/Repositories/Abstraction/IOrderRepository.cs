using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface IOrderRepository
{
    public Task<Order> Save(Order order);
    public Task<Order> Update(Order order);
    public Task Delete(int id);
    Task<List<MenuItem>> ListOrderedMenuItems(int reservationId);
    Task<List<OrderItem>> ListOrdersAndMenuItems(int reservationId);
}
