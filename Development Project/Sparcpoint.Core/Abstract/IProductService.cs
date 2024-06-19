using Sparcpoint.Data.Entities;
using Sparcpoint.Data.Models;
using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparcpoint.Abstract
{
    public interface IProductService
    {
        Products GetProductById(int id);

        List<Product> SeacrhProduct(SearchCriteria searchcriteria);

        string AddPrdouct(Products products);
    }
}
