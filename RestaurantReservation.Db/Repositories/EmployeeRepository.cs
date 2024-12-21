using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetManagers()
    {
        return await _context.Employees.Where(emp => emp.Position == Positions.Manager).ToListAsync();
    }
    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        return await _context.Orders.Where(o => o.EmployeeId == employeeId)
            .AverageAsync(x => x.TotalPrice);

    }

    public async Task<Employee> Save(Employee employee)
    {
        var savedEmployee = await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return savedEmployee.Entity;
    }

    public async Task<Employee> Update(Employee employee)
    {
        var updatedEmployee = _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return updatedEmployee.Entity;
    }

    public async Task Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return;
        }
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
