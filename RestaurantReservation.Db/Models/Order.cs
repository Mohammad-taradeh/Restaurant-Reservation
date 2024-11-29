﻿namespace RestaurantReservation.Db.Models;

public class Order
{
    public int OrderId { get; set; }

    public int? ReservationId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime OrderDate { get; set; }

    public double TotalPrice { get; set; }

    public Employee Employee { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public Reservation Reservation { get; set; }
}