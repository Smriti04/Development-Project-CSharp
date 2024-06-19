using System;
using System.Collections.Generic;
using System.Text;

namespace Sparcpoint.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImageUris { get; set; }
        public string ValidSkus { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public IEnumerable<Category> CategoryIds { get; set; } //EVAL :Assuming the categories is a dropdown and can get the Ids from the UI
        public IEnumerable<Attribute> Attributes { get; set; }
    }
}
