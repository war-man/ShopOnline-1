using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class sao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "589a1377-28d5-4ffd-94c0-c1e8815b3390");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d0389b0-89b6-48f5-9eee-91a2baf40eca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b72e1f28-0101-4ddf-a329-8f26f1be8d4d");

            migrationBuilder.DropColumn(
                name: "PoductSizeId",
                table: "ProductQuantities");

            migrationBuilder.AddColumn<int>(
                name: "ProductSizeId",
                table: "ProductQuantities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31d54ffe-f785-4894-8787-54df03588fa4", "086c77ad-0a48-4f38-9110-23b27f291eb3", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91afa18b-e5b1-494a-b195-b71f82eda193", "2915e971-04dc-47ee-b622-bafe359b42af", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b64a35c6-3191-4344-85f8-e047b56f0971", "346f3b16-a0bf-4889-930c-bce31e5d56d7", "Customer", "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31d54ffe-f785-4894-8787-54df03588fa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91afa18b-e5b1-494a-b195-b71f82eda193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b64a35c6-3191-4344-85f8-e047b56f0971");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "ProductQuantities");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PoductSizeId",
                table: "ProductQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "589a1377-28d5-4ffd-94c0-c1e8815b3390", "7d1f88ac-1ca4-431c-9efa-9806513d7752", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b72e1f28-0101-4ddf-a329-8f26f1be8d4d", "f477b358-10df-4442-9dcc-8b0ad264bb73", "Staff", "Staff" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d0389b0-89b6-48f5-9eee-91a2baf40eca", "cd360795-745b-4519-aa9f-f3768bb9cd38", "Customer", "Customer" });
        }
    }
}
