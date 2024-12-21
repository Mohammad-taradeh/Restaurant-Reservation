using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface IEmployeeRepository
{
    Task<Employee> Save(Employee employee);
    Task<Employee> Update(Employee employee);
    Task Delete(int id);
    Task<List<Employee>> GetManagers();
    Task<double> CalculateAverageOrderAmount(int employeeId);
}
