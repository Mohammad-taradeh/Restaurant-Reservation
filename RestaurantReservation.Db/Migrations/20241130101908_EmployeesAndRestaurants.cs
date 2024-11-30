using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesAndRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW EmployeesRestaurants
                AS
                SELECT E.EmployeeID, E.FirstName + ' ' + E.LastName AS EmployeeName, E.Position, R.RestaurantId, R.Name As Restaurant
                FROM Employees AS E
                LEFT JOIN Restaurants AS R
                ON E.RestaurantId = R.RestaurantId"
             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EmployeesRestaurants");
        }
    }
}
