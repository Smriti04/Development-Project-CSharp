using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sparcpoint.Data.Entities
{
    [Table("ProductCategories", Schema = "INSTANCES")]
    public class ProductCategories
    {
        public int ProductInstanceId { get; set; }  
        public int CategoryInstanceId { get; set; }
    }
}
