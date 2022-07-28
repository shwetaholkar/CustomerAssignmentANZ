using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraining1121AngularDemo.Migrations
{
    public partial class Added_UserCollection_InCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_CustomerId",
                table: "AbpUsers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Customers_CustomerId",
                table: "AbpUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Customers_CustomerId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_CustomerId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AbpUsers");
        }
    }
}
