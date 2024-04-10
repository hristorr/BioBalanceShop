using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioBalanceShop.Infrastructure.Migrations
{
    public partial class AddedIsActiveFilterToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicator if user exists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c32793-47c7-4f3b-9487-d91c2a0e4345",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "786fda0f-44aa-4fc7-aeab-401edadd6dd7", true, "AQAAAAEAACcQAAAAENY2FrVDVUt4X0g1oa/1VoyWkfxi+XBZCDvxvzzQ3sHW4l63/vHtdcVDGIFMqgFjTw==", "c5707229-74c8-4c3d-94be-a656fe24233d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4f1530f-2727-4bc8-9de3-075fc7420586",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "915e5905-da8a-462f-8746-5d7a2652a0fe", true, "AQAAAAEAACcQAAAAEBH0nxf3Utf0OKDfyQQyRt8NwfTpJNVKFb0N0Tn0dv5DowNykGd6VMZt8q5jfXzNUw==", "03da288e-a974-4ef4-8641-89ea10fd03bd" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 820, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 917, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 17, 2, 59, 948, DateTimeKind.Local).AddTicks(1087));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c32793-47c7-4f3b-9487-d91c2a0e4345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24fc4c8a-02f8-4123-86ab-e7b5e5eeaf42", "AQAAAAEAACcQAAAAEHq5E0YsM7Dy865U/3MjsDdcKubUU9dW0sS26tkrvwKBbL5tjHNR0g7XG2gPY/gPRQ==", "c21bfb5f-6f62-40ee-93a9-c8340490e50a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4f1530f-2727-4bc8-9de3-075fc7420586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37c2b0db-fd22-44fa-a299-d8e76c00dfaf", "AQAAAAEAACcQAAAAECR632mxgGxTsuuBGpOWxsH6F40VKKAz1u4wWn2URrzwnF3I+Op2PO4DJy+VvA2anw==", "9b5f0350-cb90-4551-9e71-6bd95e3df138" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 861, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 930, DateTimeKind.Local).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 10, 13, 18, 35, 962, DateTimeKind.Local).AddTicks(3743));
        }
    }
}
