﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FruitablesDAL.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public string CommercialName { get; set; }

    public decimal Rate { get; set; }

    public string Address { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User SellerNavigation { get; set; }
}