using GeekStore.Data.EFContext;
using GeekStore.Data.Interfaces;
using GeekStore.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekStore.Data.Repositories
{
    public class SubcategoryRepository : ISubcategory
    {
        private readonly DBContext _context;
        public SubcategoryRepository(DBContext context)
        {
            _context = context;
        }
        public IEnumerable<Subcategory> Subcategories
        {
            get
            {
                return _context.Subcategories;
            }
        }

        public List<Subcategory> GetSubcategoriesByCategoryId(int id)
        {
            return _context.Subcategories.Where(x => x.CategoryId == id).ToList();
        }
    }
}
