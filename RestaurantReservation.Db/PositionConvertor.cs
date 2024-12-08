using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db.Models;
namespace RestaurantReservation.Db;

public class PositionConvertor: ValueConverter<Positions, string>
{
    public PositionConvertor(): base(
        v => v.ToString(),
        v => (Positions) Enum.Parse(typeof(Positions), v))
    {
        
    }
}
