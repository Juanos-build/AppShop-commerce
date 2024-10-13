using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppShop.Models.Context.Model;

[Table("Product")]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string ProductName { get; set; }

    [Required]
    [StringLength(10)]
    public string ProductCode { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    [StringLength(500)]
    public string Image { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
}
