using System;
using System.Collections.Generic;

namespace ClientsProject.DAL.Entities;

public partial class Order
{
    public int Idorder { get; set; }

    public string? Name { get; set; }

    public int? Count { get; set; }

    public DateOnly? Daterelease { get; set; }

    public int IdClient { get; set; }

    public int IdProduct { get; set; }

    public int? Purchaseprice { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
