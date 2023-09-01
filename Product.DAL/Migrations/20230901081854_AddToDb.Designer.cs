﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductAPI.DAL;

#nullable disable

namespace ProductAPI.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230901081854_AddToDb")]
    partial class AddToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductAPI.Domain.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Лесные",
                            Description = "",
                            ImageId = "",
                            ImageUrl = ""
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Комнатные",
                            Description = "",
                            ImageId = "",
                            ImageUrl = ""
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Лекарственный",
                            Description = "",
                            ImageId = "",
                            ImageUrl = ""
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Садовые",
                            Description = "",
                            ImageId = "",
                            ImageUrl = ""
                        });
                });

            modelBuilder.Entity("ProductAPI.Domain.Entity.Image", b =>
                {
                    b.Property<string>("ImageId")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ProductAPI.Domain.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(288),
                            Description = "Майский ландыш – единственный представитель рода Ландыши. Корневище ландыша ползучее, у верхушки несколько бледных мелких листьев, наполовину скрытых в земле.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 15m,
                            ProductName = "Ландыш",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(325),
                            Description = "Жасмин — это род из 200 или более листопадных кустарников, вьющихся или вьющихся растений, которые выращивают в основном из-за их белых, розовых или желтых сильно ароматных цветов.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 13.99m,
                            ProductName = "Жасмин",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(345),
                            Description = "Растение травянистое многолетнее высотой 10-50 см, с длинночерешковыми, широкоовальными, крупными зимующими листьями темно-зеленого цвета, собранными в розетку при корне. Когда лето заканчивается, у Бадана краснеют листья. У него длинное, толстое, ветвистое и ползучее корневище.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 10.99m,
                            ProductName = "Бадан толстолистный",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(363),
                            Description = "Название растение получило из-за особой формы цветка, бутоны очень похожи на голову дельфина. По древней греческой легенде у одного юноши погибла возлюбленная, не в силах пережить боль утраты он сделал статую девушки и вдохнул в нее жизнь. Боги разгневались на такую дерзость и превратили юношу в дельфина. Возрожденная девушка однажды вышла на берег моря и увидела дельфина, он подплыл к ней и положил к ее ногам веточку Дельфиниума.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 15m,
                            ProductName = "Дельфиниум",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 3,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(381),
                            Description = "Гвоздика пышная встречается по всей европейской части России, кроме Юга и Крайнего Севера, растет в Средней Азии, в Западной и Восточной Сибири. Наиболее часто встречается по опушкам лесов, в лугах, в разреженных лесах, а также встречается в горах, где растет выше лесного пояса. Этот лесной цветок является многолетним корневищным травянистым растением.Высотой от 25 до 60 см.Обладает супротивными листьями и немногими цветоносными стеблями с цветами необычайной красоты.Пурпурные, розовые или белые цветы с глубоко рассеченными лепестками напоминают тончайшие кружева мастерицы.Цветет с начала июня до июля.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 18m,
                            ProductName = "Гвоздика пышная",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 3,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(404),
                            Description = "Свое народное название – Водосбор, Аквилегия получила из-за особого строения цветка, каждый из которых имеет несколько «карманчиков», которые во время дождя наполняются водой, то есть «собирают воду». У декоративных видов данная функция отсутствует, но у Водосбора настоящего (см. фото) есть такие карманчики. Аквилегия или Водосбор являются травянистыми многолетними растениями.Его видов насчитывается около 70 видов.В дикой природе растение произрастает в лесах и лугах, Водосбор широко распространен в горных областях Северного полушария.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 25m,
                            ProductName = "Аквилегия (Водосбор)",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 4,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(422),
                            Description = "Родиной Айвы японской является Япония и Китай, значительно распространена в России – не только в южной части страны, но и в средней полосе. Связано это с тем, что данный цветущий кустарник прекрасно переносит морозы. Даже если его ветки в холодный период года подмерзают – сам куст остается. Название «Северный лимон» Айва японская получила благодаря плодам – ярко желтым с характерным запахом и вкусом лимона.Хотя и по содержанию витамина С этот кустарник цветущий практически не уступает настоящему лимону.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 19m,
                            ProductName = "Айва японская",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 2,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(440),
                            Description = "Родиной Зефирантеса является Центральная Америка. В настоящий момент это довольно распространенное и популярное декоративное растение, выращиваемое в основном как комнатный цветок. Народное название «Выскочка» образовалось из - за интересной особенности растения: его бутоны довольно быстро появляются из - под земли, и если пару дней назад даже предпосылок к цветению не было, то сегодня оно уже все может быть в цветах.",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 18m,
                            ProductName = "Зефирантес",
                            ShortDescription = ""
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            CreateDateTime = new DateTime(2023, 9, 1, 11, 18, 53, 707, DateTimeKind.Local).AddTicks(459),
                            Description = "Название Колокольчика произошло из латинского языка, в дословном переводе означающий колокол. По народному поверью, цветы Колокольчиков один раз в году звенят, происходит это в сказочную ночь накануне праздника Ивана Купалы. Колокольчик – травянистое растение, имеющее более трёхсот видов.Наиболее часто цветы встречаются в Европе, на Кавказе, в Сибири, Колокольчик предпочитает умеренный климат.Растет цветок в полях, лесах и лугах, встречается также на скальных и пустынных участках, некоторые виды также растут в лесу.В последнее время Колокольчик активно высаживается на садовых участках..",
                            ImageId = "",
                            ImageUrl = "",
                            Price = 18m,
                            ProductName = "Колокольчик",
                            ShortDescription = ""
                        });
                });

            modelBuilder.Entity("ProductAPI.Domain.Entity.Image", b =>
                {
                    b.HasOne("ProductAPI.Domain.Entity.Product", null)
                        .WithMany("SecondaryImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductAPI.Domain.Entity.Product", b =>
                {
                    b.HasOne("ProductAPI.Domain.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductAPI.Domain.Entity.Product", b =>
                {
                    b.Navigation("SecondaryImages");
                });
#pragma warning restore 612, 618
        }
    }
}