using GeekStore.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekStore.Data.ViewModels
{
    public class SearchViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        
    }
}
