using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStore.Data.Migrations
{
    public partial class ItemOrder_FK_ShoppingCartID_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_ShoppingCarts_ShoppingCartID",
                table: "ItemOrders");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartID",
                table: "ItemOrders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_ShoppingCarts_ShoppingCartID",
                table: "ItemOrders",
                column: "ShoppingCartID",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_ShoppingCarts_ShoppingCartID",
                table: "ItemOrders");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartID",
                table: "ItemOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_ShoppingCarts_ShoppingCartID",
                table: "ItemOrders",
                column: "ShoppingCartID",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
