using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AkilliTicaretYazilim.DbModels
{
    public partial class Products
    {
        public Products()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        [Key]
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(CategoryID))]
        [InverseProperty(nameof(Categories.Products))]
        public virtual Categories Category { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
