using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using CommonLayer;
using System.IO;

namespace RepositoryLayer
{
    public class ProductRepository : DataRepository<Product, int>
    {
        private static ECommerceEntities db = Tools.GetConnection();
        ResultProcess<Product> result = new ResultProcess<Product>();
        public override Result<int> Delete(int id)
        {
            Product silinecek = db.Products.SingleOrDefault(t => t.ProductId == id);
          

            string fullPath = AppDomain.CurrentDomain.BaseDirectory + "\\Upload\\";
            foreach (string item in silinecek.Photo.Split(','))
            {
                if (item == "" || item == " ")
                {
                    continue;
                }
                File.Delete(fullPath + item);
            }
            db.Products.Remove(silinecek);
            return result.GetResult(db);
        }

        public override Result<List<Product>> GetLatestObj(int Quantity)
        {
            return result.GetListResult(db.Products.OrderByDescending(t => t.ProductId).Take(Quantity).ToList());
        }

        public override Result<Product> GetObjById(int id)
        {
            return result.GetT(db.Products.SingleOrDefault(t => t.ProductId == id));
        }

        public override Result<int> Insert(Product item)
        {
            db.Products.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Product>> List()
        {
            return result.GetListResult(db.Products.ToList());
        }

        public override Result<int> Update(Product item)
        {
            Product gunP = db.Products.SingleOrDefault(t => t.ProductId == item.ProductId);
            gunP.BrandId = item.BrandId;
            gunP.CategoryId = item.CategoryId;
            gunP.Price = item.Price;
            gunP.Stock = item.Stock;
            gunP.ProductName = item.ProductName;
            gunP.Photo = item.Photo;
            return result.GetResult(db);
        }
    }
}
