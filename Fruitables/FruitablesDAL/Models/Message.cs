﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FruitablesDAL.Models;

public partial class Message
{
    [Key]
    [Column("messageID")]
    public int MessageId { get; set; }

    [Required]
    [Column("title")]
    [StringLength(50)]
    public string Title { get; set; }

    [Required]
    [Column("content")]
    [StringLength(255)]
    public string Content { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column("userID")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Messages")]
    public virtual User User { get; set; }
}