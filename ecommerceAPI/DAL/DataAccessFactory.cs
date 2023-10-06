using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Category, int, Category> CategoryData()
        {
            return new CategoryRepo();
        }
        public static IRepo<Product, int, Product> ProductData()
        {
            return new ProductRepo();
        }
        public static IProductRepo<Product> ProductData1()
        {
            return new ProductRepo();
        }

        public static IRepo<Cart, int, Cart> CartData()
        {
            return new CartRepo();
        }
        public static IRepo<Customer, int, Customer> CustomerData()
        {
            return new CustomerRepo();
        }
        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }
       
        public static IRepo<Review, int, Review> ReviewData()
        {
            return new ReviewRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Offer, int, Offer> OfferData()
        {
            return new OfferRepo();
        }
        public static IRepo<CartItem, int, CartItem> CartItemData()
        {
            return new CartItemRepo();
        }


    }
}
