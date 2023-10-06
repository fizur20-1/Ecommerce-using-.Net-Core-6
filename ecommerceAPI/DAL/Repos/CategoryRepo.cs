using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CategoryRepo : Repo, IRepo<Category, int, Category>
    {
        public Category Create(Category obj)
        {
            db.Categories.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Categories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
           // return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category Update(Category obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            else return null;
        }
    }


}
    

