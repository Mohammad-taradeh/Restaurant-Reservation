using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Views;
using System.Reflection.Emit;
namespace RestaurantReservation.Db.Configurations;

public class ReservationsCustomersAndRestaurentsConfiguration : IEntityTypeConfiguration<ReservationsCustomersAndRestaurants>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ReservationsCustomersAndRestaurants> builder)
    {
       builder.HasNoKey()
           .ToView(nameof(ReservationsCustomersAndRestaurants));
    }
}
