using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Abstraction;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return;
        }
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<Customer> Save(Customer customer)
    {
        var savedCustomer = await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return savedCustomer.Entity;
    }

    public async Task<Customer> Update(Customer customer)
    {
        var updatedCustomer = _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return updatedCustomer.Entity;
    }
}
