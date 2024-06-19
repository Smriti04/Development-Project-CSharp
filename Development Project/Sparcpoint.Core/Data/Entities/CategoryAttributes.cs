using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sparcpoint.Data.Entities
{
    [Table("CategoryAttributes", Schema = "INSTANCES")]
    public class CategoryAttributes
    {
        public int CategoryInstanceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
