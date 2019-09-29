using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace CommonLayer
{
    public class ResultProcess<T>
    {
        public Result<int> GetResult(ECommerceEntities db)
        {
            Result<int> result = new Result<int>();
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                result.UserMessage = "Basarili";
                result.IsSucceeded = true;
                result.ProcessResult = sonuc;
            }
            else
            {
                result.UserMessage = "Basarisiz";
                result.IsSucceeded = false;
                result.ProcessResult = sonuc;

            }
            return result;
        }

        public Result<List<T>> GetListResult(List<T> data)
        {
            Result<List<T>> result = new Result<List<T>>();
            if (data != null)
            {
                result.UserMessage = "islem basarili";
                result.IsSucceeded = true;
                result.ProcessResult = data;
            }
            else
            {
                result.UserMessage = "islem basarisiz data yok";
                result.IsSucceeded = false;
                result.ProcessResult = data;
            }
            return result;
        }

        public Result<T> GetT(T data)
        {
            Result<T> result = new Result<T>();
            if (data != null)
            {
                result.IsSucceeded = true;
                result.UserMessage = "Basarili";
                result.ProcessResult = data;
            }
            else
            {
                result.IsSucceeded = false;
                result.UserMessage = "Basarisiz";
                result.ProcessResult = data;

            }
            return result;
        }
    }
}
