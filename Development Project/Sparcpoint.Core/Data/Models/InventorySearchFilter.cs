using System;
using System.Collections.Generic;
using System.Text;
using Attribute = Sparcpoint.Models.Attribute;

namespace Sparcpoint.Data.Models
{
    public class InventorySearchFilter
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string SKUNumber { get; set; }
        public Attribute MaetaData { get; set; }
    }
}
