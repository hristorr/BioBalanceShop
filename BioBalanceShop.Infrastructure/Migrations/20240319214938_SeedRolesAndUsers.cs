using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioBalanceShop.Infrastructure.Migrations
{
    public partial class SeedRolesAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03f649d4-5366-4680-97d0-a90777f42356", "fc8917eb-9e60-4c9b-ac62-e0863189b488", "admin", "ADMIN" },
                    { "ca7cd2a7-6e5f-4e74-9df1-3b6b5fb25r53", "4ebfb060-ed31-4c13-b759-add97b278264", "customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShopId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02c32793-47c7-4f3b-9487-d91c2a0e4345", 0, "f80d6c43-fc0f-481f-b9ef-d93bcadb460e", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEEe2kDSoqIvyiVKBCC3c1O+jpmXI92l+rUIrkZWLO4GQbcz9mIhwTzrYUEhRih1LfA==", null, false, "3808835a-6a74-4a3f-bbd4-db2e4e719c00", null, false, "admin@mail.com" },
                    { "c4f1530f-2727-4bc8-9de3-075fc7420586", 0, "e1886255-bd12-46c9-b9cd-f7853f4ce829", "customer@mail.com", true, false, null, "CUSTOMER@MAIL.COM", "CUSTOMER@MAIL.COM", "AQAAAAEAACcQAAAAEMs59kbt7K1Yc96VgMInh6ZkUpOu1QW3KoF09yQB6vIc6KnQIDOumR9EowNOPCm8Ag==", null, false, "55713733-c7b9-463f-ba82-fc5acb7070b1", null, false, "customer@mail.com" }
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
