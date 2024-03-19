using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioBalanceShop.Infrastructure.Migrations
{
    public partial class UsersAndRolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03f649d4-5366-4680-97d0-a90777f42356", "91cbf97f-a30b-4601-9f3c-e7570764ff07", "admin", "ADMIN" },
                    { "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53", "a7aa4bd2-2d73-45e6-bab3-9fe628b02517", "customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShopId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02c32793-47c7-4f3b-9487-d91c2a0e4345", 0, "fe1ad454-c0e8-4510-80af-6724ef2490b5", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEMUiVavCWQ2Tv+nPNL/bSKGVDkr7T6s/vpYyaxK2wQbWGkvQK+rSvykFA1dipdu4Ug==", null, false, "d8b1aa6a-a90e-42a1-bdab-8151400d5032", null, false, "admin@mail.com" },
                    { "c4f1530f-2727-4bc8-9de3-075fc7420586", 0, "5b8849df-f5c9-457e-8910-1e8fc0e95e5d", "customer@mail.com", true, false, null, "CUSTOMER@MAIL.COM", "CUSTOMER@MAIL.COM", "AQAAAAEAACcQAAAAEOUDA/Gp9icQlKYKPo3KZ18fQJsypIWacCVUShSmr3MIdUjZq9lZCUVEeB4jbEhWeQ==", null, false, "212a5d34-f316-4386-b902-db8ffbe7a1bf", null, false, "customer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "03f649d4-5366-4680-97d0-a90777f42356", "02c32793-47c7-4f3b-9487-d91c2a0e4345" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53", "c4f1530f-2727-4bc8-9de3-075fc7420586" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "03f649d4-5366-4680-97d0-a90777f42356", "02c32793-47c7-4f3b-9487-d91c2a0e4345" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53", "c4f1530f-2727-4bc8-9de3-075fc7420586" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f649d4-5366-4680-97d0-a90777f42356");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c32793-47c7-4f3b-9487-d91c2a0e4345");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4f1530f-2727-4bc8-9de3-075fc7420586");
        }
    }
}
