using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CommonLayer;

namespace RepositoryLayer
{
    public class OrderDetailRep : DataRepository<OrderDetail, int>
    {
        private static ECommerceEntities db = Tools.GetConnection();
        ResultProcess<OrderDetail> result = new ResultProcess<OrderDetail>();
        public override Result<int> Delete(int id)
        {
            List<OrderDetail> OdList = db.OrderDetails.Where(t => t.OrderId == id).ToList();
            db.OrderDetails.RemoveRange(OdList);
            return result.GetResult(db);
        }

        public override Result<List<OrderDetail>> GetLatestObj(int Quantity)
        {
            throw new NotImplementedException();
        }

        public override Result<OrderDetail> GetObjById(int id)
        {
            throw new NotImplementedException();
        }

        public override Result<int> Insert(OrderDetail item)
        {
            db.OrderDetails.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<OrderDetail>> List()
        {
            return result.GetListResult(db.OrderDetails.ToList());
        }

        public override Result<int> Update(OrderDetail item)
        {
            OrderDetail OrdDet = db.OrderDetails.SingleOrDefault(t => t.OrderId == item.OrderId & t.ProductId == item.ProductId);
            OrdDet.Quantity = item.Quantity;
            OrdDet.Price = item.Price;
            return result.GetResult(db);
        }

        public Result<int> OrderDetailSil(int OrdId, int ProId)
        {
            OrderDetail od = db.OrderDetails.SingleOrDefault(t => t.OrderId == OrdId & t.ProductId == ProId);
            db.OrderDetails.Remove(od);
            return result.GetResult(db);
        }
        public Result<List<OrderDetail>> GetListByOrdId(int Id)
        {
            return result.GetListResult(db.OrderDetails.Where(t => t.OrderId == Id).ToList());
        }

        public Result<OrderDetail> GetOrderDetByTwoID(int OD, int PID)
        {
            OrderDetail od = db.OrderDetails.SingleOrDefault(t => t.OrderId == OD & t.ProductId == PID);
            return result.GetT(od);
        }
    }
}
