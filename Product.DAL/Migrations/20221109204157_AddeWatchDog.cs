using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    public partial class AddeWatchDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 41, 57, 210, DateTimeKind.Local).AddTicks(6688));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 9, 23, 32, 13, 556, DateTimeKind.Local).AddTicks(8873));
        }
    }
}
