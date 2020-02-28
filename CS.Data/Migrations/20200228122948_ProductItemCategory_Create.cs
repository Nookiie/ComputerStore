using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStore.Data.Migrations
{
    public partial class ProductItemCategory_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ProductItem_ProductItemID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_ProductItem_ProductItemID",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_ShoppingCarts_ShoppingCartID",
                table: "ItemOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductItem",
                table: "ProductItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrder",
                table: "ItemOrder");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "ProductItem");

            migrationBuilder.RenameTable(
                name: "ProductItem",
                newName: "ProductItems");

            migrationBuilder.RenameTable(
                name: "ItemOrder",
                newName: "ItemOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_ShoppingCartID",
                table: "ItemOrders",
                newName: "IX_ItemOrders_ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_ProductItemID",
                table: "ItemOrders",
                newName: "IX_ItemOrders_ProductItemID");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductItems",
                table: "ProductItems",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ProductItemCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemCategory", x => new { x.CategoryID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_ProductItemCategory_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemCategory_ProductItems_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_Name",
                table: "ProductItems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemCategory_ProductID",
                table: "ProductItemCategory",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ProductItems_ProductItemID",
                table: "Categories",
                column: "ProductItemID",
                principalTable: "ProductItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_ProductItems_ProductItemID",
                table: "ItemOrders",
                column: "ProductItemID",
                principalTable: "ProductItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_ShoppingCarts_ShoppingCartID",
                table: "ItemOrders",
                column: "ShoppingCartID",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ProductItems_ProductItemID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_ProductItems_ProductItemID",
                table: "ItemOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_ShoppingCarts_ShoppingCartID",
                table: "ItemOrders");

            migrationBuilder.DropTable(
                name: "ProductItemCategory");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductItems",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_Name",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductItems");

            migrationBuilder.RenameTable(
                name: "ProductItems",
                newName: "ProductItem");

            migrationBuilder.RenameTable(
                name: "ItemOrders",
                newName: "ItemOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_ShoppingCartID",
                table: "ItemOrder",
                newName: "IX_ItemOrder_ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_ProductItemID",
                table: "ItemOrder",
                newName: "IX_ItemOrder_ProductItemID");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "ProductItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductItem",
                table: "ProductItem",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrder",
                table: "ItemOrder",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ProductItem_ProductItemID",
                table: "Categories",
                column: "ProductItemID",
                principalTable: "ProductItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_ProductItem_ProductItemID",
                table: "ItemOrder",
                column: "ProductItemID",
                principalTable: "ProductItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_ShoppingCarts_ShoppingCartID",
                table: "ItemOrder",
                column: "ShoppingCartID",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
