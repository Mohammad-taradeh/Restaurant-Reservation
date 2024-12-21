using RestaurantReservation.Db.Models;
namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface ICustomerRepository
{
    Task<Customer> Save(Customer customer);
    Task<Customer> Update(Customer customer);
    Task Delete(int id);
}
