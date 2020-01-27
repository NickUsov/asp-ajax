using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        List<Good> goods = new List<Good>() { new Good { Id=1, Title="Samsung", Category="Phones", Price=3500},
                                            new Good { Id=2, Title="IPhone", Category="Phones", Price=18000},
                                            new Good { Id=3, Title="Xiaomi", Category="Phones", Price=6799},
                                            new Good { Id=4, Title="Midea", Category="Climatics", Price=9899},
                                            new Good { Id=5, Title="Samsung S39L", Category="Kitchen", Price=1800},
                                            new Good { Id=6, Title="Samsung S890", Category="Kitchen", Price=2300}};
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            IEnumerable<string> categories = goods.Select(g => g.Category).Distinct();
            return View(categories);
        }

        public ActionResult SearchRes(string category)
        {
            IEnumerable<Good> results = goods.Where(g => g.Category.ToLower().Contains(category.ToLower()));
            if(results==null)
            {
                return HttpNotFound();
            }
            ViewBag.SearchPattern = category;
            return PartialView(results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public JsonResult JsonSearch(string category)
        {
            IEnumerable<Good> results = goods.Where(g => g.Category.ToLower().Contains(category.ToLower()));
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}