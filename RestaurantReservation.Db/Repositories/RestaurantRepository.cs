using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private RestaurantReservationDbContext _context;

    public RestaurantRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if(restaurant == null)
        {
            return;
        }
        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
        
    }

    public async Task<Restaurant> Save(Restaurant restaurant)
    {
        var savedRestaurant = await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
        return savedRestaurant.Entity;
    }

    public async Task<Restaurant> Update(Restaurant restaurant)
    {
        var updateRestaurant = _context.Restaurants.Update(restaurant);
        await _context.SaveChangesAsync();
        return updateRestaurant.Entity;
    }
}
