using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    public partial class AddToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    ImageId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ImageId = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "CategoryName", "Description", "ImageId", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Лесные", "", "", "" },
                    { 2, "Комнатные", "", "", "" },
                    { 3, "Лекарственный", "", "", "" },
                    { 4, "Садовые", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateDateTime", "Description", "ImageId", "ImageUrl", "Price", "ProductName", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(288), "Майский ландыш – единственный представитель рода Ландыши. Корневище ландыша ползучее, у верхушки несколько бледных мелких листьев, наполовину скрытых в земле.", "", "", 15m, "Ландыш", "" },
                    { 2, 2, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(325), "Жасмин — это род из 200 или более листопадных кустарников, вьющихся или вьющихся растений, которые выращивают в основном из-за их белых, розовых или желтых сильно ароматных цветов.", "", "", 13.99m, "Жасмин", "" },
                    { 3, 3, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(345), "Растение травянистое многолетнее высотой 10-50 см, с длинночерешковыми, широкоовальными, крупными зимующими листьями темно-зеленого цвета, собранными в розетку при корне. Когда лето заканчивается, у Бадана краснеют листья. У него длинное, толстое, ветвистое и ползучее корневище.", "", "", 10.99m, "Бадан толстолистный", "" },
                    { 4, 4, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(363), "Название растение получило из-за особой формы цветка, бутоны очень похожи на голову дельфина. По древней греческой легенде у одного юноши погибла возлюбленная, не в силах пережить боль утраты он сделал статую девушки и вдохнул в нее жизнь. Боги разгневались на такую дерзость и превратили юношу в дельфина. Возрожденная девушка однажды вышла на берег моря и увидела дельфина, он подплыл к ней и положил к ее ногам веточку Дельфиниума.", "", "", 15m, "Дельфиниум", "" },
                    { 5, 3, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(381), "Гвоздика пышная встречается по всей европейской части России, кроме Юга и Крайнего Севера, растет в Средней Азии, в Западной и Восточной Сибири. Наиболее часто встречается по опушкам лесов, в лугах, в разреженных лесах, а также встречается в горах, где растет выше лесного пояса. Этот лесной цветок является многолетним корневищным травянистым растением.Высотой от 25 до 60 см.Обладает супротивными листьями и немногими цветоносными стеблями с цветами необычайной красоты.Пурпурные, розовые или белые цветы с глубоко рассеченными лепестками напоминают тончайшие кружева мастерицы.Цветет с начала июня до июля.", "", "", 18m, "Гвоздика пышная", "" },
                    { 6, 3, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(404), "Свое народное название – Водосбор, Аквилегия получила из-за особого строения цветка, каждый из которых имеет несколько «карманчиков», которые во время дождя наполняются водой, то есть «собирают воду». У декоративных видов данная функция отсутствует, но у Водосбора настоящего (см. фото) есть такие карманчики. Аквилегия или Водосбор являются травянистыми многолетними растениями.Его видов насчитывается около 70 видов.В дикой природе растение произрастает в лесах и лугах, Водосбор широко распространен в горных областях Северного полушария.", "", "", 25m, "Аквилегия (Водосбор)", "" },
                    { 7, 4, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(422), "Родиной Айвы японской является Япония и Китай, значительно распространена в России – не только в южной части страны, но и в средней полосе. Связано это с тем, что данный цветущий кустарник прекрасно переносит морозы. Даже если его ветки в холодный период года подмерзают – сам куст остается. Название «Северный лимон» Айва японская получила благодаря плодам – ярко желтым с характерным запахом и вкусом лимона.Хотя и по содержанию витамина С этот кустарник цветущий практически не уступает настоящему лимону.", "", "", 19m, "Айва японская", "" },
                    { 8, 2, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(440), "Родиной Зефирантеса является Центральная Америка. В настоящий момент это довольно распространенное и популярное декоративное растение, выращиваемое в основном как комнатный цветок. Народное название «Выскочка» образовалось из - за интересной особенности растения: его бутоны довольно быстро появляются из - под земли, и если пару дней назад даже предпосылок к цветению не было, то сегодня оно уже все может быть в цветах.", "", "", 18m, "Зефирантес", "" },
                    { 9, 1, new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(459), "Название Колокольчика произошло из латинского языка, в дословном переводе означающий колокол. По народному поверью, цветы Колокольчиков один раз в году звенят, происходит это в сказочную ночь накануне праздника Ивана Купалы. Колокольчик – травянистое растение, имеющее более трёхсот видов.Наиболее часто цветы встречаются в Европе, на Кавказе, в Сибири, Колокольчик предпочитает умеренный климат.Растет цветок в полях, лесах и лугах, встречается также на скальных и пустынных участках, некоторые виды также растут в лесу.В последнее время Колокольчик активно высаживается на садовых участках..", "", "", 18m, "Колокольчик", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
