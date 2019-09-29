using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceExample.Models.ResultModel;
using EntityLayer;
using RepositoryLayer;
using System.Web.Security;

namespace ECommerceExample.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        InstanceResult<Member> result = new InstanceResult<Member>();
        MemberRepository mr = new MemberRepository();
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(Member member)
        {
            if (ModelState.IsValid)
            {
                using (ECommerceEntities context = new ECommerceEntities())
                {
                    var user = context.Members.FirstOrDefault(x => x.Email == member.Email && x.Password == member.Password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.FirstName, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ViewBag.Message = "Kullanici adi veya parola yanlıs";
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Member member)
        {
            member.RoleId = 3;
            result.resultint = mr.Insert(member);
            if (result.resultint.IsSucceeded)
                return RedirectToAction("Login", "Account");
            else
                return View(member);
        }
        public ActionResult MyProfile()
        {
            foreach (Member member in mr.List().ProcessResult)
            {
                if (User.Identity.Name == member.FirstName)
                {
                    return View(member);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult MyProfile(Member member)
        {
            result.resultint = mr.Update(member);
            if (result.resultint.IsSucceeded)
                return RedirectToAction("Index", "Home");
            else
                return View(member);
        }
        [Authorize]
        public ActionResult MyOrders(int id)
        {
            List<Order> myOrder = new List<Order>();
            OrderRepository or = new OrderRepository();
            foreach (Order item in or.List().ProcessResult)
            {
                if (item.MemberId == id)
                {
                    myOrder.Add(item);
                }
            }
            return View(myOrder);
        }
    }
}