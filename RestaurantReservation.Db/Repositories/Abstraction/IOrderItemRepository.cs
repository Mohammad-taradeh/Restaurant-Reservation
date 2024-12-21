using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface IOrderItemRepository
{
    public Task<OrderItem> Save(OrderItem orderItem);
    public Task<OrderItem> Update(OrderItem orderItem);
    public Task Delete(int id);
}
