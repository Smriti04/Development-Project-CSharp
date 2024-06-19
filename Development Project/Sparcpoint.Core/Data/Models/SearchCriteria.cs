using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Attribute = Sparcpoint.Models.Attribute;

namespace Sparcpoint.Data.Models
{
    public class SearchCriteria
    {
        public string Name { get; set; } 
        public string SKUNumber { get; set; }
        public Attribute MaetaData { get; set; }
        public Category Category { get; set; }
    }
}
