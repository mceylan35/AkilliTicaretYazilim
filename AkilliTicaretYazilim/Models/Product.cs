using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliTicaretYazilim.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
    }
}
