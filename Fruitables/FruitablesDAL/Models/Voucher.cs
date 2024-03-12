﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FruitablesDAL.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; }

    public DateTime ExpireDate { get; set; }

    public bool IsActive { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<CustomersVoucher> CustomersVouchers { get; set; } = new List<CustomersVoucher>();
}