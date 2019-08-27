using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dz1.Models;

namespace Dz1.Repository
{
    public class GoodRepository
    {
        private readonly ShopAdoEntities _context = new ShopAdoEntities();
        public IEnumerable<Good> GetAll()
        {
            return _context.Goods.ToList();
        }

        public void RemoveGood(int id)
        {
            var re = _context.Goods.SingleOrDefault(c => c.GoodId == id);
            if (re != null)
            {
                _context.Goods.Remove(re);
            }
            _context.SaveChanges();
        }

        ~GoodRepository()
        {
            _context.Dispose();
        }
    }
}