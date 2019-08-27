using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dz1.Models;

namespace Dz1.Repository
{
    public class ManufacturerRepository
    {
        private readonly ShopAdoEntities _context = new ShopAdoEntities();
        public IEnumerable<Manufacturer> GetAll()
        {
            return _context.Manufacturers.ToList();
        }

        public void RemoveManufacturer(int id)
        {
            var re = _context.Manufacturers.SingleOrDefault(c => c.ManufacturerId == id);
            if (re != null)
            {
                _context.Manufacturers.Remove(re);
            }
            _context.SaveChanges();
        }

        ~ManufacturerRepository()
        {
            _context.Dispose();
        }
    }
}