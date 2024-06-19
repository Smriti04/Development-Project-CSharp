using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sparcpoint.Data.Entities
{
    [Table("CategoryCategories", Schema = "INSTANCES")] 
    public class CategoryCategories
    {
        public int CategoryId { get; set; }
        public int CategoryInstanceId { get; set; }

    }
}
