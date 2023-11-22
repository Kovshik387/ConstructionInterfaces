using System;
using System.Collections.Generic;

namespace ClientsProject.DAL.Entities;

public partial class Client
{
    public int IdClient { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Contact { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Rating { get; set; }

    public string Type { get; set; } = null!;

    public DateOnly? Lastvisit { get; set; }

    public DateOnly? Registrationdate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Viewclient> Viewclients { get; set; } = new List<Viewclient>();
}
