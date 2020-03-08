using GeekStore.Data.Tables;
using GeekStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeekStore.Data.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public string Price { get; set; }
        public int Discount { get; set; }
        public int ProductId { get; set; }
        public List<ProductAdminModel> Products { get; set; }

    }
}
