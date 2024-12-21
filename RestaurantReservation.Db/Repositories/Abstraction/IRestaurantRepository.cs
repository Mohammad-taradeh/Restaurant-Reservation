using RestaurantReservation.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories.Abstraction;

public interface IRestaurantRepository
{
    public Task<Restaurant> Save(Restaurant restaurant);
    public Task<Restaurant> Update(Restaurant restaurant);
    public Task Delete(int id);
}
