using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AkilliTicaretYazilim.DbModels
{
    public partial class OrderProducts
    {
        [Key]
        public int ID { get; set; }
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        [Column(TypeName = "decimal(19, 1)")]
        public decimal? Price { get; set; }

        [ForeignKey(nameof(OrderID))]
        [InverseProperty(nameof(Orders.OrderProducts))]
        public virtual Orders Order { get; set; }
        [ForeignKey(nameof(ProductID))]
        [InverseProperty(nameof(Products.OrderProducts))]
        public virtual Products Product { get; set; }
    }
}
