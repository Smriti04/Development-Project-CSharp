using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sparcpoint.Data.Entities
{
    [Table("CATEGORIES",Schema = "INSTANCES")]
    public class Category
    {
        [Key]
        public int InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
