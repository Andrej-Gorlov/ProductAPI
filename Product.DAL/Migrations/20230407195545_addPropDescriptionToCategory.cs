using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    public partial class addPropDescriptionToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categorys",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "CreateDateTime",
                value: new DateTime(2023, 4, 7, 22, 55, 44, 668, DateTimeKind.Local).AddTicks(6612));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categorys");

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
    }
}
