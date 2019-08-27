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
        private readonly int PER_PAGE = 6;

        public decimal GetCountPages(int value)
        {
            return Math.Ceiling((decimal)value / PER_PAGE);
        }

        // GET: Shop
        public ActionResult Goods(int id = 1)
        {
            var goods = _goods.GetAll();
            int countPagesGoods = (int)GetCountPages(goods.Count());

            ViewBag.Goods = goods
                    .Take(PER_PAGE)
                    .Skip((id - 1) * countPagesGoods);
            ViewBag.CountPagesGoods = countPagesGoods;

            return View();
        }

        public ActionResult Categories(int id = 1)
        {
            var categories = _categories.GetAll();
            int countPagesCategories = (int)GetCountPages(categories.Count());

            ViewBag.Categories = categories
                    .Take(PER_PAGE)
                    .Skip((id - 1) * countPagesCategories);
            ViewBag.CountPagesCategories = countPagesCategories;

            return View();
        }

        public ActionResult Manufacturers(int id = 1)
        {
            var manufacturers = _manufacturers.GetAll();
            int countPagesManufacturers = (int)GetCountPages(manufacturers.Count());
            ViewBag.Manufacturers = manufacturers
                        .Take(PER_PAGE)
                        .Skip((id - 1) * countPagesManufacturers);
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