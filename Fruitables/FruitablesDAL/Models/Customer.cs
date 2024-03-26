#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FruitablesDAL.Models;

public partial class Customer
{
    [Key]
    [Column("customerID")]
    public int CustomerId { get; set; }

    [Required]
    [Column("address")]
    [StringLength(255)]
    public string Address { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Customer")]
    public virtual User CustomerNavigation { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<CustomersVoucher> CustomersVouchers { get; set; } = new List<CustomersVoucher>();

    [InverseProperty("Customer")]
    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Customer")]
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}