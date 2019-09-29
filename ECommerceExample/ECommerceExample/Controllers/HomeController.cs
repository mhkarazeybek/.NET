using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using RepositoryLayer;

namespace ECommerceExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        ProductRepository pr = new ProductRepository();
        public ActionResult Index()
        {
            ViewBag.CurrentUser = User.Identity.Name;
            return View(pr.List().ProcessResult);
        }

        public ActionResult Detail(int id)
        {
            Product p = pr.GetObjById(id).ProcessResult;
            return View(p);
        }

        public ActionResult List(Guid? id)
        {
            List<Product> pList = pr.List().ProcessResult.Where(t => t.CategoryId == id).ToList();
            return View(pList);
        }
        public ActionResult ListByBrand(int? id)
        {
            List<Product> pList = pr.List().ProcessResult.Where(t => t.BrandId == id).ToList();
            return View(pList);
        }
        public ActionResult ListAllProduct()
        {
            return View(pr.List().ProcessResult);
        }
    }
}