namespace RestaurantReservation.Db.Repositories;

public class BaseRepository<T> where T : class
{
    protected RestaurantReservationDbContext _dbContext;
    public BaseRepository(RestaurantReservationDbContext context)
    {
        _dbContext = context;
    }
    public virtual void Create(T entity)
    {
        _dbContext.Add<T>(entity);
        _dbContext.SaveChanges();
    }
    public virtual void Update(T entity)
    {
        _dbContext.Update<T>(entity);
         _dbContext.SaveChanges();
    }
    public virtual void Delete(int id)
    {
        var objToDelete = _dbContext.Find<T>(id);
        if (objToDelete != null)
        {
            _dbContext.Remove(objToDelete);
            _dbContext.SaveChanges();
        }
        else Console.WriteLine("Not found");
    }
}
