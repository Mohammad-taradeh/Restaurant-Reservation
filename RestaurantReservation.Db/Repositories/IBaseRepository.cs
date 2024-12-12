
namespace RestaurantReservation.Db.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}