﻿namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string OpeningHoures { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public ICollection<Table> Tables { get; set; } = new List<Table>();
}