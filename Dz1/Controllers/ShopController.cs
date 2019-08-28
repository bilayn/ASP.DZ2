using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz1.Repository;

namespace Dz1.Controllers
{
    public class ShopController : Controller
    {
        private readonly GoodRepository _goods = new GoodRepository();
        private readonly ManufacturerRepository _manufacturers = new ManufacturerRepository();
        private readonly CategoryRepository _categories = new CategoryRepository();
        private readonly int _perPage = 6;

        public int GetCountPages(int value)
        {
            return (int)Math.Ceiling((decimal)value / _perPage);
        }

        // GET: Shop
        public ActionResult Goods(int id = 1)
        {
            var goods = _goods.GetAll().ToList();
            var countPagesGoods = GetCountPages(goods.Count());

            ViewBag.Goods = goods
                    .Skip((id - 1) * _perPage)
                    .Take(_perPage);
            ViewBag.CountPagesGoods = countPagesGoods;

            return View();
        }

        public ActionResult Categories(int id = 1)
        {
            var categories = _categories.GetAll();
            var countPagesCategories = GetCountPages(categories.Count());

            ViewBag.Categories = categories
                    .Skip((id - 1) * _perPage)
                    .Take(_perPage);
            ViewBag.CountPagesCategories = countPagesCategories;

            return View();
        }

        public ActionResult Manufacturers(int id = 1)
        {
            var manufacturers = _manufacturers.GetAll();
            var countPagesManufacturers = GetCountPages(manufacturers.Count());
            ViewBag.Manufacturers = manufacturers
                        .Skip((id - 1) * _perPage)
                        .Take(_perPage);
            ViewBag.CouuntPagesManufacturers = countPagesManufacturers;

            return View();
        }

        public ActionResult RemoveGood(int id)
        {
            _goods.RemoveGood(id);
            return RedirectToAction("Goods");
        }

        public ActionResult RemoveCategory(int id)
        {
            _categories.RemoveCategory(id);
            return RedirectToAction("Categories");
        }

        public ActionResult RemoveManufacturer(int id)
        {
            _manufacturers.RemoveManufacturer(id);
            return RedirectToAction("Manufacturers");
        }
    }
}