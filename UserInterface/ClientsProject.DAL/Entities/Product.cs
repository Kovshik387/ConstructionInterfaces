using System;
using System.Collections.Generic;

namespace ClientsProject.DAL.Entities;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public int? Count { get; set; }

    public DateOnly? Daterelease { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
