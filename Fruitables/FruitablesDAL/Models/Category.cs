﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FruitablesDAL.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}