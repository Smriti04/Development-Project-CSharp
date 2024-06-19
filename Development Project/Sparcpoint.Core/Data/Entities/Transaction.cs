using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sparcpoint.Data.Entities
{
    [Table("InventoryTransactions",Schema = "Transactions")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int ProductInstanceId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime StartedTimestamp { get; set; }
        public DateTime CompletedTimestamp { get; set; }
        public string TypeCategory { get; set; }
    }
}
