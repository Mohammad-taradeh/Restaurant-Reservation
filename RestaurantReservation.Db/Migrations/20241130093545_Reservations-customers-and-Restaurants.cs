using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationscustomersandRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW ReservationCustomersAndRestaurants
                    AS
                    SELECT V.ReservationId, R.RestaurantId, R.Name, C.CustomerId, C.FirstName + ' ' + C.LastName AS CustomerName
                    FROM Reservations AS V
                    LEFT JOIN Restaurants AS R ON V.RestaurantId = R.RestaurantId
                    LEFT JOIN Customers AS C ON V.CustomerId = C.CustomerId"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservationCustomersAndRestaurants");
        }
    }
}
