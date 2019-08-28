using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz1.Repository;

namespace Dz1.Controllers
{
    public class PartialShopController : Controller
    {
        
        private readonly GoodRepository _goods = new GoodRepository();
        private readonly ManufacturerRepository _manufacturers = new ManufacturerRepository();
        private readonly CategoryRepository _categories = new CategoryRepository();
        private readonly int _perPage = 6;


        public ActionResult Goods(int id = 1)
        {
            ViewBag.CountPagesGoods = GetCountPages(_goods.GetAll().Count()); 
            return View();
        }

        public ActionResult GoodsTable(int id = 1, int removeId = -1)
        {
            try
            {
                if (removeId != -1)
                {
                    _goods.RemoveGood(removeId);
                }
            }
            catch
            {
                // ignored
            }


            var goods = _goods.GetAll()
                .Skip((id - 1) * _perPage)
                .Take(_perPage);
                
            return PartialView(goods);
        }

        public ActionResult Categories(int id = 1)
        {
            ViewBag.CountPagesCategories = GetCountPages(_categories.GetAll().Count()); ;
            return View();
        }


        public ActionResult CategoriesTable(int id = 1, int removeId = -1)
        {
            try
            {
                if (removeId != -1)
                {
                    _categories.RemoveCategory(removeId);
                }
            }
            catch 
            {
                // ignored
            }

            var categories = _categories.GetAll()
                .Skip((id - 1) * _perPage)
                .Take(_perPage);

            return PartialView(categories);
        }


        public ActionResult Manufacturers(int id = 1)
        {
            ViewBag.CouuntPagesManufacturers = GetCountPages(_manufacturers.GetAll().Count());
            return View();
        }

        public ActionResult ManufacturersTable(int id = 1, int removeId = -1)
        {
            try
            {
                if (removeId != -1)
                {
                    _manufacturers.RemoveManufacturer(removeId);
                }
            }
            catch
            {
                // ignored
            }

            var manufacturers = _manufacturers
                .GetAll()
                .Skip((id - 1) * _perPage)
                .Take(_perPage);

            return PartialView(manufacturers);
        }

        public int GetCountPages(int value)
        {
            return (int)Math.Ceiling((decimal)value / _perPage);
        }
    }
}