using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioBalanceShop.Infrastructure.Migrations
{
    public partial class SetCustomerIdInOrdersNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: true,
                comment: "Customer identificator",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Customer identificator");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c32793-47c7-4f3b-9487-d91c2a0e4345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36799de0-0e16-486e-9d7d-70b127b2d49c", "AQAAAAEAACcQAAAAEBoTMJpUvPd9QWXUinCdbMw5HyEjixrMH2PxgyFPkRihSEA2dvuVaLMXK9q+2P78/g==", "6b58c3ab-b226-44c0-8cfd-9ce16ecbaa50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4f1530f-2727-4bc8-9de3-075fc7420586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "876f43a5-512c-4d40-a4bb-52ba4d921ca4", "AQAAAAEAACcQAAAAEGWZuDoP6gFt+5UF3W7Z5tYiwyeWQEDs0ZJ7An1Cd0iOt0bML2+20ayNx83S1veKgw==", "ad72e4e7-3f92-427c-ac34-ba5db1e6d1b3" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 126, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 198, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 8, 1, 11, 10, 216, DateTimeKind.Local).AddTicks(1489));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Customer identificator",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Customer identificator");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c32793-47c7-4f3b-9487-d91c2a0e4345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8885cca-805e-45ba-8074-10b94fda340b", "AQAAAAEAACcQAAAAECCpVDcTAMGOxlp+wIDXvR+n0AhnHy/gp9ro0joQSr6CVF0NCAz7tHU1IcPoF0s4zA==", "311c9b8c-69fa-4001-87c0-6df1927091ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4f1530f-2727-4bc8-9de3-075fc7420586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a8697c8-544c-41b7-9fc0-3f57eb551279", "AQAAAAEAACcQAAAAED6sZMSDXPDIh3TS9IrYe78T1PPk3SVxCFWoqNVxDUQRZYhJJpGtKy3pmnlGVGxPNg==", "8ea54be6-cfe7-49db-9fac-4094d7349128" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 239, DateTimeKind.Local).AddTicks(624));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 316, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 5, 19, 336, DateTimeKind.Local).AddTicks(3863));
        }
    }
}
