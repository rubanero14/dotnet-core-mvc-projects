﻿// <auto-generated />
using Menu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Menu.Migrations
{
    [DbContext(typeof(MenuContext))]
    [Migration("20240624054346_initial migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSenWY1zGZX5wjVw5PJVZF2D7WEz5Z4Dkq11w&s",
                            Name = "Pizza Neapolitana",
                            Price = 7.9900000000000002
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngredient", b =>
                {
                    b.Property<int>("DishID")
                        .HasColumnType("int");

                    b.Property<int>("IngredientID")
                        .HasColumnType("int");

                    b.HasKey("DishID", "IngredientID");

                    b.HasIndex("IngredientID");

                    b.ToTable("DishIngredients");

                    b.HasData(
                        new
                        {
                            DishID = 1,
                            IngredientID = 1
                        },
                        new
                        {
                            DishID = 1,
                            IngredientID = 2
                        },
                        new
                        {
                            DishID = 1,
                            IngredientID = 3
                        },
                        new
                        {
                            DishID = 1,
                            IngredientID = 4
                        });
                });

            modelBuilder.Entity("Menu.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mozarella Cheese"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tomato Sauce"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dough"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Basil"
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngredient", b =>
                {
                    b.HasOne("Menu.Models.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menu.Models.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("Menu.Models.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
