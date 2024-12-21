using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository : ITableRepository
{
    private RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var table = await _context.Tables.FindAsync(id);
        if (table == null)
        {
            return;
        }
        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
    }

    public async Task<Table> Save(Table table)
    {
        var savedTable = await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
        return savedTable.Entity;
    }

    public async Task<Table> Update(Table table)
    {
        var updatedTable = _context.Tables.Update(table);
        await _context.SaveChangesAsync();
        return updatedTable.Entity;
    }
}
