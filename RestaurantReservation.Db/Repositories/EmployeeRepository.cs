using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : BaseRepository<Employee>
{
    public EmployeeRepository(RestaurantReservationDbContext context) : base(context)
    {
    }

    public List<Employee> GetManagers()
    {
        return _dbContext.Employees.Where(emp => emp.Position == Positions.Manager).ToList();
    }
    public double CalculateAverageOrderAmount(int employeeId)
    {
        return _dbContext.Orders.Where(o => o.EmployeeId == employeeId)
            .Average(x => x.TotalPrice);

    }
}
