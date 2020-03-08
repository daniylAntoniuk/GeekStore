using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekStore.Models
{
    public class ProductAdminModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }     
    }
}
