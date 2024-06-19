using Sparcpoint.Abstract;
using Sparcpoint.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparcpoint.Infrastructure.Services.Implementation
{
    public class InventoryService :IInventoryService
    {
        private readonly ProductContext _dbContext;

        public InventoryService(ProductContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void AddInventory(int productId,decimal quantity) 
        {
            var data = _dbContext.Transaction.Where(x => x.ProductInstanceId == productId).Select(x => x).ToList();
            if(data.Count> 0)
            {
                //Do not add
            }
            _dbContext.Transaction.Add(new Data.Entities.Transaction
            {
                ProductInstanceId = productId,
                Quantity = quantity,
                StartedTimestamp = DateTime.Now,
                CompletedTimestamp = DateTime.Now,
                TypeCategory = "Add"

            });
            _dbContext.SaveChanges();
        }
        public string RemoveFromInventory(int transactionId)
        {
            var data = _dbContext.Transaction.Where(x => x.TransactionId == transactionId).Select(x => x);
            var msg = "";
            if(data.Any())
            {
                _dbContext.Transaction.RemoveRange(data);
                _dbContext.SaveChanges();
                msg = "Data Deleted Sucessfully";
                return msg;
            }
            return msg;
        }
        public decimal GetInventoryCount(InventorySearchFilter filter)
        {
            decimal count = 0;

            if(filter != null && filter.ProductId!=null)
            {
                count = _dbContext.Transaction.
                    Where(x => x.ProductInstanceId == filter.ProductId).
                    Select(x => x.Quantity).First();
                return count;
            }
            else if(filter != null && filter.SKUNumber!=null)
            {
                count = (from t in _dbContext.Transaction
                         join p in _dbContext.Product on
                         t.ProductInstanceId equals p.InstanceId
                         where p.ValidSkus == filter.SKUNumber
                         select t.Quantity).FirstOrDefault();
                return count!=null ? count : 0;
            }
            else if (filter != null && filter.MaetaData!=null)
            {
                count=(from t in _dbContext.Transaction
                      join attr in _dbContext.Attributes on
                      t.ProductInstanceId equals attr.ProductId
                      where attr.Key==filter.MaetaData.Key && attr.Value==filter.MaetaData.Value
                      select t.Quantity).ToList().Sum();
                return count;
            }
            return count;

        }
    }
}
