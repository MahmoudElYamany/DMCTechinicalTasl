using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class database4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "orderHeaders",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "orderHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_StateId",
                table: "orderHeaders",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_statuses_StateId",
                table: "orderHeaders",
                column: "StateId",
                principalTable: "statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_statuses_StateId",
                table: "orderHeaders");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropIndex(
                name: "IX_orderHeaders_StateId",
                table: "orderHeaders");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "orderHeaders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
