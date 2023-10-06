using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, Product>, IProductRepo<Product>
    {
        public Product Create(Product obj)
        {
            db.Products.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Products.Remove(ex);// make changed products.IsDeleted= true. do same for others. we need soft delete .
            return db.SaveChanges() > 0;

        }

        public List<Product> Get()
        {

            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetAll(string category, string subCategory, int count)
        {
           
                IQueryable<Product> query = db.Products;

                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(p => p.Category.category == category);
                }

                if (!string.IsNullOrEmpty(subCategory))
                {
                    query = query.Where(p => p.Category.SubCategory == subCategory);
                }

                if (count > 0)
                {
                    query = query.Take(count);
                }

                var products = query.ToList();

                return products;
            

        }

        public Product Update(Product obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            else return null;
        }
    }

}
