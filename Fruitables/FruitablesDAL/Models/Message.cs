﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FruitablesDAL.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime Date { get; set; }

    public bool IsActive { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }
}