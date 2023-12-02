using System;
using System.Collections.Generic;

namespace wpf_sessiya1.DbModels;

public partial class Tag
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
