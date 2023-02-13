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
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7441));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 38, 54, 440, DateTimeKind.Local).AddTicks(7527));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2023, 2, 13, 20, 37, 54, 806, DateTimeKind.Local).AddTicks(2923));
        }
    }
}
