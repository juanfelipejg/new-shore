using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewShore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JourneysAddedToFlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
