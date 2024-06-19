using Sparcpoint.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparcpoint.Abstract
{
    public interface IInventoryService
    {
        void AddInventory(int productId, decimal quantity);
        string RemoveFromInventory(int transactionId);
        decimal GetInventoryCount(InventorySearchFilter filter);
    }
}
