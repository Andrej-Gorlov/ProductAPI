using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    public partial class addPropShortDescriptionToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(189), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(231), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(261), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(291), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(320), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(349), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(404), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(433), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "CreateDateTime", "ShortDescription" },
                values: new object[] { new DateTime(2023, 4, 19, 19, 41, 32, 512, DateTimeKind.Local).AddTicks(462), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Products");

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
    }
}
