using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AkilliTicaretYazilim.DbModels
{
    public partial class Categories
    {
        public Categories()
        {
            InverseParent = new HashSet<Categories>();
            Products = new HashSet<Products>();
        }

        [Key]
        public int ID { get; set; }
        public int? ParentID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }

        [ForeignKey(nameof(ParentID))]
        [InverseProperty(nameof(Categories.InverseParent))]
        public virtual Categories Parent { get; set; }
        [InverseProperty(nameof(Categories.Parent))]
        public virtual ICollection<Categories> InverseParent { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
