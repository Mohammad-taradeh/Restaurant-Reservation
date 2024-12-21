using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface ITableRepository
{
    public Task<Table> Save(Table table);
    public Task<Table> Update(Table table);
    public Task Delete(int id);
}
