using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AkilliTicaretYazilim.DbModels
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        [Key]
        public int ID { get; set; }
        public int? CustomerID { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Price { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
