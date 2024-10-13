using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppShop.Models.Context.Model;

[Table("ProductOrder")]
public partial class ProductOrder
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("ProductOrders")]
    public virtual Order Order { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductOrders")]
    public virtual Product Product { get; set; }
}
