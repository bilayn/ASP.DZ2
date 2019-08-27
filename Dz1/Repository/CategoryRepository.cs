using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dz1.Models;

namespace Dz1.Repository
{
    public class CategoryRepository
    {
        private readonly ShopAdoEntities _context = new ShopAdoEntities();
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void RemoveCategory(int id)
        {
            var re = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (re != null)
            {
                _context.Categories.Remove(re);
            }
            _context.SaveChanges();
        }
        ~CategoryRepository()
        {
            _context.Dispose();
        }
    }
}