﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FruitablesDAL.Models;

public partial class Item
{
    [Key]
    [Column("itemID")]
    public int ItemId { get; set; }

    [Required]
    [Column("address")]
    [StringLength(255)]
    public string Address { get; set; }

    [Column("discount", TypeName = "decimal(5, 1)")]
    public decimal? Discount { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("subTotalPrice", TypeName = "decimal(5, 1)")]
    public decimal SubTotalPrice { get; set; }

    [Column("momentPrice", TypeName = "decimal(5, 1)")]
    public decimal MomentPrice { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column("orderID")]
    public int OrderId { get; set; }

    [Column("productID")]
    public int ProductId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Items")]
    public virtual Order Order { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Items")]
    public virtual Product Product { get; set; }
}