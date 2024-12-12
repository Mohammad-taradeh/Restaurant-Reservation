namespace RestaurantReservation.Db.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected RestaurantReservationDbContext _dbContext;
    public BaseRepository(RestaurantReservationDbContext context)
    {
        _dbContext = context;
    }
    public virtual async Task Create(T entity)
    {
        _dbContext.Add<T>(entity);
        await _dbContext.SaveChangesAsync();
    }
    public virtual async Task Update(T entity)
    {
        _dbContext.Update<T>(entity);
        await _dbContext.SaveChangesAsync();
    }
    public virtual async Task Delete(int id)
    {
        var objToDelete = _dbContext.Find<T>(id);
        if (objToDelete != null)
        {
            _dbContext.Remove(objToDelete);
            await _dbContext.SaveChangesAsync();
        }
        else Console.WriteLine("Not found");
    }
}
