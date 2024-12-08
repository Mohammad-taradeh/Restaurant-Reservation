using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class fn_restaurant_revenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION fn_calculate_resturants_revenue(@RestaurantId int)
                RETURNS DECIMAL
                AS 
                BEGIN
	                DECLARE @Revenue DECIMAL;
	                SELECT @Revenue = SUM(O.TotalPrice)
	                FROM Restaurants AS R
	                LEFT JOIN Reservations AS V
	                ON R.RestaurantId = V.RestaurantId
	                LEFT JOIN Orders AS O
	                ON O.ReservationId = V.ReservationId
	                WHERE R.RestaurantId = @RestaurantId
	                RETURN @Revenue
                END
              ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION fn_calculate_resturants_revenue");
        }
    }
}
