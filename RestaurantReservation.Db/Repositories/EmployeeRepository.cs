using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : BaseRepository<Employee>
{
    public EmployeeRepository(RestaurantReservationDbContext context) : base(context)
    {
    }

    public async Task<List<Employee>> GetManagers()
    {
        return await _dbContext.Employees.Where(emp => emp.Position == Positions.Manager).ToListAsync();
    }
    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        return await _dbContext.Orders.Where(o => o.EmployeeId == employeeId)
            .AverageAsync(x => x.TotalPrice);

    }
}
