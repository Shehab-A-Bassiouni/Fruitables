﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FruitablesDAL.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string Address { get; set; }

    public decimal? Discount { get; set; }

    public int Quantity { get; set; }

    public decimal SubTotalPrice { get; set; }

    public decimal MomentPrice { get; set; }

    public bool IsActive { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}