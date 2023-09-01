using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    public partial class AddWatchDogToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 20, 7, 522, DateTimeKind.Local).AddTicks(7658));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(459));
        }
    }
}
