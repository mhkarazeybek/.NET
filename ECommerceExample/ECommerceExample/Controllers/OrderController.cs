using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using CommonLayer;
using RepositoryLayer;

namespace ECommerceExample.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        OrderRepository or = new OrderRepository();
        ProductRepository pr = new ProductRepository();
        OrderDetailRep ordrep = new OrderDetailRep();
        MemberRepository mr = new MemberRepository();
        public ActionResult Add(int id)
        {
            int memberId = 0;
            foreach (Member item in mr.List().ProcessResult)
            {
                if (item.FirstName == User.Identity.Name)
                {
                    memberId = item.UserId;
                    break;
                }
            }
            //Sepetimizi Sessionda tutuyoruz. Burada ki Sessionun adi=Order(Session[Order])
            if (Session["Order"] == null)
            {
                Order o = new Order();
                o.OrderDate = DateTime.Now;
                o.IsPay = false;

                if (memberId != 0)
                    o.MemberId = memberId;

                or.Insert(o);
                Session["Order"] = or.GetLatestObj(1).ProcessResult[0];
                OrderDetail od = new OrderDetail();
                od.OrderId = ((Order)Session["Order"]).OrderId;
                od.ProductId = id;
                od.Quantity = 1;
                od.Price = pr.GetObjById(id).ProcessResult.Price;
                ordrep.Insert(od);
            }
            else
            {
                Order o = (Order)Session["Order"];
                OrderDetail Update = ordrep.GetOrderDetByTwoID(o.OrderId, id).ProcessResult;
                if (Update == null)
                {

                    OrderDetail od = new OrderDetail();
                    od.OrderId = o.OrderId;
                    od.ProductId = id;
                    od.Quantity = 1;
                    od.Price = pr.GetObjById(id).ProcessResult.Price;
                    ordrep.Insert(od);

                }
                else
                {
                    Update.Quantity++;
                    Update.Price += pr.GetObjById(id).ProcessResult.Price;
                    ordrep.Update(Update);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult DetailList()
        {
            Order sepetim = (Order)Session["Order"];
            decimal? TotalPrice = 0;
            OrderRepository or = new OrderRepository();
            if (sepetim.OrderDetails != null)
            {
                foreach (OrderDetail item in sepetim.OrderDetails)
                {
                    TotalPrice += item.Price;
                }
                sepetim.TotalPrice = TotalPrice;
                or.Update(sepetim);
            }
            else
            {
                sepetim.TotalPrice = 0;
                or.Update(sepetim);
            }
            if (sepetim == null)
            {
                return RedirectToAction("ListAllProduct", "Home");
            }
            else
            {
                return View(sepetim.OrderDetails);
            }
        }

        public ActionResult Delete(int id)
        {
            Order sepetim = (Order)Session["Order"];
            Result<int> result = ordrep.OrderDetailSil(sepetim.OrderId, id);
            return RedirectToAction("DetailList");
        }
    }
}