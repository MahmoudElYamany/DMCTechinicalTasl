using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_Discounts_DiscountID",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "orderHeaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_Discounts_DiscountID",
                table: "orderHeaders",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_Discounts_DiscountID",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "orderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_Discounts_DiscountID",
                table: "orderHeaders",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
