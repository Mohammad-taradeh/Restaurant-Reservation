using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Views;
using System.Reflection.Emit;

namespace RestaurantReservation.Db.Configurations;

public class EmployeeAndRestaurentsConfigurations : IEntityTypeConfiguration<EmployeesAndRestaurants>
{
    public void Configure(EntityTypeBuilder<EmployeesAndRestaurants> builder)
    {
       builder.HasNoKey()
            .ToView(nameof(EmployeesAndRestaurants));
    }
}
