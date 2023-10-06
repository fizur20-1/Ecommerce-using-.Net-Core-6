using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CartItemRepo : Repo, IRepo<CartItem, int, CartItem>
    {
        public CartItem Create(CartItem obj)
        {
            db.CartItems.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.CartItems.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<CartItem> Get()
        {
            return db.CartItems.ToList();
        }

        public CartItem Get(int id)
        {
            return db.CartItems.Find(id);
        }

        public CartItem Update(CartItem obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            else return null;
        }
    }
}
