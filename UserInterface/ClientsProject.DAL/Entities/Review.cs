using System;
using System.Collections.Generic;

namespace ClientsProject.DAL.Entities;

public partial class Review
{
    public int IdReview { get; set; }

    public int Rating { get; set; }

    public string? Message { get; set; }

    public DateOnly Date { get; set; }

    public bool? Ishelpful { get; set; }

    public int IdClient { get; set; }

    public int? IdProduct { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Product? IdProductNavigation { get; set; }
}
