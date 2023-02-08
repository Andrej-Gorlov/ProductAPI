using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    public partial class AddWatchDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 50, 40, 638, DateTimeKind.Local).AddTicks(651));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 8, 23, 49, 40, 571, DateTimeKind.Local).AddTicks(4649));
        }
    }
}
