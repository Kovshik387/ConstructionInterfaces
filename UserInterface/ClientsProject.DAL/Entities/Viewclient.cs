using System;
using System.Collections.Generic;

namespace ClientsProject.DAL.Entities;

public partial class Viewclient
{
    public int IdView { get; set; }

    public int IdClient { get; set; }

    public int IdProduct { get; set; }

    public DateOnly? Dateview { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
