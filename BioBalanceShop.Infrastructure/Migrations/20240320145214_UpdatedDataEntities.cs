using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioBalanceShop.Infrastructure.Migrations
{
    public partial class UpdatedDataEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shops_ShopId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerBillingAddresses_CustomerBillingAddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerShippingAddresses_CustomerShippingAddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderBillingAddresses_OrderBillingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderShippingAddresses_OrderShippingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_AspNetUsers_OwnerId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "CustomerBillingAddresses");

            migrationBuilder.DropTable(
                name: "OrderBillingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Shops_OwnerId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderBillingAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderShippingAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerBillingAddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerShippingAddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShopId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Logotype",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "ImageBack",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageFront",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderBillingAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderShippingAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ImageBack",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ImageFront",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CustomerBillingAddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerShippingAddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderItems",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                comment: "Product description",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Product description");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Products",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "",
                comment: "Product ingredients");

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingFee",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true,
                comment: "Product shipping fee");

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Product subtitle");

            migrationBuilder.AddColumn<int>(
                name: "OrderAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Order address identificator");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: true,
                comment: "Customer address identificator");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                comment: "Customer first name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                comment: "Customer last name");

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product image identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if product image exists"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false, comment: "Product image"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identificator"),
                    OrderItemId = table.Column<int>(type: "int", nullable: false, comment: "Order item identificator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f649d4-5366-4680-97d0-a90777f42356",
                column: "ConcurrencyStamp",
                value: "e81e6a1b-8747-45c3-8cae-0cc86e6f97a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53",
                column: "ConcurrencyStamp",
                value: "38af0150-cff9-4276-9bd8-af8f0326f579");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c32793-47c7-4f3b-9487-d91c2a0e4345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "842b4235-2862-4739-8d4c-7f0d4cd14251", "AQAAAAEAACcQAAAAEJshm8fDISP8fpLMQljQmKPJFX4I2yBzyDK/46vYJ42UdvDVvV9dMC+dwt4Xq6Br+w==", "24141816-6660-4796-91f5-6148edf3b808" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4f1530f-2727-4bc8-9de3-075fc7420586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a032bba8-481f-4bc3-8acf-dc1a6399c824", "AQAAAAEAACcQAAAAENt3E1X8tyoBaIC7UzPvlKma4fSHJv0Wk1U1XUtCfCnvdwOM75TdHvmTKDbLtkdfrg==", "1fbde278-42a5-4a04-ae12-31661a625283" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_OrderItemId",
                table: "ProductImage",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerShippingAddresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "CustomerShippingAddresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderShippingAddresses_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId",
                principalTable: "OrderShippingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerShippingAddresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderShippingAddresses_OrderAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShippingFee",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "OrderItems",
                newName: "Name");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logotype",
                table: "Shops",
                type: "varbinary(max)",
                nullable: true,
                comment: "Shop logotype");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shops",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Shop name");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Shops",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Shop owner identificator");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Product description",
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldComment: "Product description");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBack",
                table: "Products",
                type: "varbinary(max)",
                nullable: true,
                comment: "Product back image");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFront",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                comment: "Product front image");

            migrationBuilder.AddColumn<int>(
                name: "OrderBillingAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Order billing address identificator");

            migrationBuilder.AddColumn<int>(
                name: "OrderShippingAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Order shipping address identificator");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderItems",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "Order item description");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBack",
                table: "OrderItems",
                type: "varbinary(max)",
                nullable: true,
                comment: "Order item back image");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFront",
                table: "OrderItems",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                comment: "Order item front image");

            migrationBuilder.AddColumn<int>(
                name: "CustomerBillingAddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Customer billing address identificator");

            migrationBuilder.AddColumn<int>(
                name: "CustomerShippingAddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Customer shipping address identificator");

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerBillingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Customer billing address identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Customer billing address country identificator"),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Customer billing address city"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if customer billing address exists"),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Customer billing address post code"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Customer billing address street name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBillingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBillingAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderBillingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order billing address identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Order billing address country identificator"),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Order billing address city"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if order billing address exists"),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Order billing address post code"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Order billing address street name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBillingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderBillingAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f649d4-5366-4680-97d0-a90777f42356",
                column: "ConcurrencyStamp",
                value: "91cbf97f-a30b-4601-9f3c-e7570764ff07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53",
                column: "ConcurrencyStamp",
                value: "a7aa4bd2-2d73-45e6-bab3-9fe628b02517");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c32793-47c7-4f3b-9487-d91c2a0e4345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe1ad454-c0e8-4510-80af-6724ef2490b5", "AQAAAAEAACcQAAAAEMUiVavCWQ2Tv+nPNL/bSKGVDkr7T6s/vpYyaxK2wQbWGkvQK+rSvykFA1dipdu4Ug==", "d8b1aa6a-a90e-42a1-bdab-8151400d5032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4f1530f-2727-4bc8-9de3-075fc7420586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b8849df-f5c9-457e-8910-1e8fc0e95e5d", "AQAAAAEAACcQAAAAEOUDA/Gp9icQlKYKPo3KZ18fQJsypIWacCVUShSmr3MIdUjZq9lZCUVEeB4jbEhWeQ==", "212a5d34-f316-4386-b902-db8ffbe7a1bf" });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_OwnerId",
                table: "Shops",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderBillingAddressId",
                table: "Orders",
                column: "OrderBillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderShippingAddressId",
                table: "Orders",
                column: "OrderShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerBillingAddressId",
                table: "Customers",
                column: "CustomerBillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerShippingAddressId",
                table: "Customers",
                column: "CustomerShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShopId",
                table: "AspNetUsers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBillingAddresses_CountryId",
                table: "CustomerBillingAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBillingAddresses_CountryId",
                table: "OrderBillingAddresses",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shops_ShopId",
                table: "AspNetUsers",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerBillingAddresses_CustomerBillingAddressId",
                table: "Customers",
                column: "CustomerBillingAddressId",
                principalTable: "CustomerBillingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerShippingAddresses_CustomerShippingAddressId",
                table: "Customers",
                column: "CustomerShippingAddressId",
                principalTable: "CustomerShippingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderBillingAddresses_OrderBillingAddressId",
                table: "Orders",
                column: "OrderBillingAddressId",
                principalTable: "OrderBillingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderShippingAddresses_OrderShippingAddressId",
                table: "Orders",
                column: "OrderShippingAddressId",
                principalTable: "OrderShippingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_AspNetUsers_OwnerId",
                table: "Shops",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
