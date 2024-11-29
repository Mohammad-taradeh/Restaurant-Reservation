﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    [Migration("20241129130934_Seeding")]
    partial class Seeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "201160@ppu.edu.ps",
                            FirstName = "Mohammad",
                            LastName = "Ahmad",
                            PhoneNumber = "0569726909"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "201116@ppu.edu.ps",
                            FirstName = "Amjad",
                            LastName = "Khanaysa",
                            PhoneNumber = "0569726909"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "55226@ppu.edu.ps",
                            FirstName = "Ahmad",
                            LastName = "Ameer",
                            PhoneNumber = "0569726909"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            FirstName = "Sabah",
                            LastName = "Ba'raa",
                            Position = "Manager",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeID = 2,
                            FirstName = "Mostafa",
                            LastName = "Tahboub",
                            Position = "Employee",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeID = 3,
                            FirstName = "Mohammad",
                            LastName = "Taradeh",
                            Position = "Owner",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeID = 4,
                            FirstName = "Ahmad",
                            LastName = "Jabari",
                            Position = "Employee",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeID = 5,
                            FirstName = "Ibrahim",
                            LastName = "Khamaisa",
                            Position = "Employee",
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Frensh fries",
                            Name = "Fries",
                            Price = 5.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Cheken with cheese",
                            Name = "Cordon Bleu",
                            Price = 25.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Crispy fried checken",
                            Name = "Crispy",
                            Price = 30.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "Chicken coocked in butter",
                            Name = "Butter Chicken",
                            Price = 35.0,
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalPrice = 100.0
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 2,
                            TotalPrice = 240.0
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 3,
                            TotalPrice = 1230.0
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 4,
                            TotalPrice = 50.0
                        },
                        new
                        {
                            OrderId = 5,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 5,
                            TotalPrice = 1000.0
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            ItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 4,
                            ItemId = 2,
                            OrderId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 2,
                            ItemId = 3,
                            OrderId = 1,
                            Quantity = 4
                        },
                        new
                        {
                            OrderItemId = 3,
                            ItemId = 3,
                            OrderId = 1,
                            Quantity = 6
                        },
                        new
                        {
                            OrderItemId = 5,
                            ItemId = 4,
                            OrderId = 1,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            Date = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PartySize = 3,
                            RestaurantId = 1,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 1,
                            Date = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PartySize = 2,
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 2,
                            Date = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PartySize = 5,
                            RestaurantId = 1,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 3,
                            Date = new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PartySize = 10,
                            RestaurantId = 1,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 2,
                            Date = new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PartySize = 7,
                            RestaurantId = 1,
                            TableId = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHoures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "Hebron",
                            Name = "Zuwar",
                            OpeningHoures = "24/7",
                            PhoneNumber = "0593929588"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 2,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 5,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 7,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 10,
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId");

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.MenuItem", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId");

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
