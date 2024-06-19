using Sparcpoint.Abstract;
using Sparcpoint.Data.Entities;
using Sparcpoint.Data.Models;
using Sparcpoint.Infrastructure;
using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparcpoint.Infrastructure.Services.Implementation
{
    public class ProductService: IProductService
    {
        private readonly ProductContext _dbContext;

        public ProductService(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Products GetProductById(int id)
        {
            List<Models.Attribute> attributes = _dbContext.Attributes.Where(x => x.ProductId == id).Select(x => new Models.Attribute { Key=x.Key,Value=x.Value }).ToList();
            List<Models.Category> categories = (from pc in _dbContext.ProductCategories
                             join c in _dbContext.Categories on pc.CategoryInstanceId equals c.InstanceId
                             where pc.ProductInstanceId == id
                             select new Models.Category { Name = c.Name, Description = c.Description }).ToList();
            Products product = new Products();
            try 
            {
                product = (from p in _dbContext.Product
                           where p.InstanceId == id
                           select new Models.Products
                           {
                               CategoryIds = categories,
                               Attributes = attributes,
                               Name = p.Name,
                               Description = p.Description,
                               ProductImageUris = p.ProductImageUris,
                               ValidSkus = p.ValidSkus,
                               CreatedTimestamp = p.CreatedTimestamp,
                           }).First();
                return product != null ? product : new Products();
            }
            catch (Exception ex)
            {
                return new Products();
                //Log Exception here
            }
        }
        public List<Product> SeacrhProduct(SearchCriteria searchcriteria)
        {
            List<int> nameSearch=new List<int>();
            List<int> skuSearch=new List<int>();
            List<int> categorySearch=new List<int>();
            List<int> attrSearch=new List<int>();
            List<int>commonProdIds=new List<int>();
            var products = _dbContext.Product.Select(r => r);
            if(searchcriteria!=null && !string.IsNullOrEmpty(searchcriteria.Name))
            {
                nameSearch = _dbContext.Product.Where(p => p.Name.Contains(searchcriteria.Name)).Select(x => x.InstanceId).ToList();
                products = products.Where(p => p.Name.Contains(searchcriteria.Name)).Select(x => x);
            }
            if(searchcriteria!=null && !string.IsNullOrEmpty(searchcriteria.SKUNumber))
            {
                skuSearch = _dbContext.Product.Where(p => p.ValidSkus.Contains(searchcriteria.SKUNumber)).Select(x => x.InstanceId).ToList();
                products = products.Where(p => p.ValidSkus.Contains(searchcriteria.SKUNumber)).Select(x => x);

            }
            if(searchcriteria!=null && searchcriteria.Category!= null)
            {
                categorySearch = (from pc in _dbContext.ProductCategories 
                             join c in _dbContext.Categories 
                             on pc.CategoryInstanceId equals c.InstanceId 
                             where c.Name.Equals(searchcriteria.Category.Name) 
                             select pc.ProductInstanceId).ToList();
                products = products.Where(x => categorySearch.Contains(x.InstanceId)).Select(x => x);
            }
            if (searchcriteria != null && searchcriteria.MaetaData != null)
            {
                attrSearch = (from attr in _dbContext.Attributes
                             join p in _dbContext.Product
                             on attr.ProductId equals p.InstanceId
                             where attr.Key.Equals(searchcriteria.MaetaData.Key)
                             && attr.Value.Equals(searchcriteria.MaetaData.Value)
                             select attr.ProductId).ToList();
                products = products.Where(x => attrSearch.Contains(x.InstanceId)).Select(x => x);
            }

            return products.ToList();
        }

        public string AddPrdouct(Products products)
        {
            var checkData=_dbContext.Product.Where(x=>x.ValidSkus==products.ValidSkus).ToList();
            var msg = "";
            if(checkData.Count>0)
            {
                //Tell user that the product already exists
            }
            else 
            {
                _dbContext.Product.Add(new Product
                {
                    Name = products.Name,
                    Description = products.Description,
                    ValidSkus = products.ValidSkus,
                    ProductImageUris = products.ProductImageUris,
                    CreatedTimestamp = products.CreatedTimestamp
                });
                _dbContext.SaveChanges();
                msg = "Product Added to the DB";
            }
            
            foreach (Models.Category c in products.CategoryIds)
            {
                var data=_dbContext.Categories.Where(x=>x.Name.Equals(c.Name)&& x.Description.Equals(c.Description)).ToList();
                if(data.Count>0)
                {
                    //Tell user that the Category already exists
                }
                else 
                {
                    _dbContext.Categories.Add(new Data.Entities.Category
                    {
                        Name = c.Name,
                        Description = c.Description,
                        Timestamp = products.CreatedTimestamp
                    });
                    _dbContext.SaveChanges();
                    msg = msg + ", Categories Added to the DB";
                }
                
            }
            foreach (Models.Attribute attr in products.Attributes)
            {
                var data=_dbContext.Attributes.Where(x=>x.Key.Equals(attr.Key)&& x.Value.Equals(attr.Value)).ToList();
                if(data.Count>0)
                {
                    //Tell user that the attribute already exists
                }
                else 
                {
                    _dbContext.Attributes.Add(new Data.Entities.ProductAttributes
                    {
                        Key = attr.Key,
                        Value = attr.Value,
                    });
                    _dbContext.SaveChanges();

                    msg = msg + " , Attributes Added to the DB";
                }
                
            }
            return msg;
        }
    }
}
