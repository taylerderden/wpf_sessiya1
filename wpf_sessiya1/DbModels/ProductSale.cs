﻿using System;
using System.Collections.Generic;

namespace wpf_sessiya1.DbModels;

public partial class ProductSale
{
    public int Id { get; set; }

    public DateTime SaleDate { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int? ClientServiceId { get; set; }

    public virtual ClientService? ClientService { get; set; }

    public virtual Product Product { get; set; } = null!;
}
