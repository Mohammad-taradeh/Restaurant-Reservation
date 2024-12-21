using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface IMenueItemRepository
{
    public Task<MenuItem> Save(MenuItem menuItem);
    public Task<MenuItem> Update(MenuItem menuItem);
    public Task Delete(int id);
}
