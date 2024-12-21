using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : IMenueItemRepository
{
    private RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var menuItem = await _context.MenuItems.FindAsync(id);
        if (menuItem == null)
        {
            return;
        }
        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task<MenuItem> Save(MenuItem menuItem)
    {
        var savedMenuItem = await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
        return savedMenuItem.Entity;
    }

    public async Task<MenuItem> Update(MenuItem menuItem)
    {
        var updatedMenuItem = _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
        return updatedMenuItem.Entity;
    }
}
