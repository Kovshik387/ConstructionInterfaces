using System;
using System.Collections.Generic;

namespace ClientsProject.DAL.Entities;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public int? Count { get; set; }

    public DateOnly? Daterelease { get; set; }

    public byte[]? Photo { get; set; }

    public int Price { get; set; }

    public string? Branch { get; set; }

    public DateOnly? Lastview { get; set; }

    public bool? Ispurchased { get; set; }

    public double? Rating { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Viewclient> Viewclients { get; set; } = new List<Viewclient>();
}
