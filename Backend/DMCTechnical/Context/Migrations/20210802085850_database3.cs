using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class database3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_headerCustomers_city_id",
                table: "headerCustomers",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_headerCustomers_country_id",
                table: "headerCustomers",
                column: "country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_headerCustomers_cities_city_id",
                table: "headerCustomers",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "City_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_headerCustomers_countries_country_id",
                table: "headerCustomers",
                column: "country_id",
                principalTable: "countries",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_headerCustomers_cities_city_id",
                table: "headerCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_headerCustomers_countries_country_id",
                table: "headerCustomers");

            migrationBuilder.DropIndex(
                name: "IX_headerCustomers_city_id",
                table: "headerCustomers");

            migrationBuilder.DropIndex(
                name: "IX_headerCustomers_country_id",
                table: "headerCustomers");

            migrationBuilder.AddColumn<int>(
                name: "title",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
