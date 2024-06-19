using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sparcpoint.Data.Entities
{
    [Table("ProductAttributes", Schema = "INSTANCES")]
    public class ProductAttributes
    {
        public int ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
