using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartItemService
    {
        public static List<CartItemDTO> Get()
        {
            var data = DataAccessFactory.CartItemData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CartItem, CartItemDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CartItemDTO>>(data);
            return mapped;
        }

        public static CartItemDTO Get(int id)
        {
            var data = DataAccessFactory.CartItemData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CartItem, CartItemDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CartItemDTO>(data);
            return mapped;
        }

        public static CartItemDTO Create(CartItemDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CartItem, CartItemDTO>();
                c.CreateMap<CartItemDTO, CartItem>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<CartItem>(obj);
            var result = DataAccessFactory.CartItemData().Create(data);
            var redata = mapper.Map<CartItemDTO>(result);
            return redata;
        }

        public static bool Delete(int Id)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CartItem, CartItemDTO>();
            });
            var mapper = new Mapper(cfg);

            var data = DataAccessFactory.CartItemData().Delete(Id);
            return data;
        }

        public static CartItemDTO Update(CartItemDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CartItem, CartItemDTO>();
                c.CreateMap<CartItemDTO, CartItem>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<CartItem>(obj);
            var result = DataAccessFactory.CartItemData().Update(data);
            var redata = mapper.Map<CartItemDTO>(result);
            return redata;
        }
    }
}
