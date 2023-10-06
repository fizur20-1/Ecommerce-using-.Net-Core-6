using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class CategoryService
    {
       
        public static List<CategoryDTO> Get()
        {
            var data = DataAccessFactory.CategoryData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CategoryDTO>>(data);
            return mapped;
        }

        public static CategoryDTO Get(int Id)
        {
            var data = DataAccessFactory.CategoryData().Get(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CategoryDTO>(data);
            return mapped;
        }
        //public static CategoryDTO Get(int id)
        //{
        //    if (id <= 0)
        //    { 
        //        // Handle invalid id, for example:
        //        throw new ArgumentException("Invalid category id.");
        //    }

        //    var data = DataAccessFactory.CategoryData().Get(id);
        //    if (data == null)
        //    {
        //        // Handle case where no category is found for the given id, for example:
        //        throw new DllNotFoundException("Category not found.");
        //    }

        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<Category, CategoryDTO>();
        //    });
        //    var mapper = new Mapper(cfg);
        //    var mapped = mapper.Map<CategoryDTO>(data);
        //    return mapped;
        //}



        public static CategoryDTO Create(CategoryDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryDTO, Category>();
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Category>(obj);
            var result = DataAccessFactory.CategoryData().Create(data);
            var redata = mapper.Map<CategoryDTO>(result);
            return redata;
        }

        public static bool Delete(int Id)
        {
           
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
         var data = DataAccessFactory.CategoryData().Delete(Id);
            return data;
        }

        public static CategoryDTO Update(CategoryDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryDTO>();
                c.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Category>(obj);
            var result = DataAccessFactory.CategoryData().Update(data);
            var redata = mapper.Map<CategoryDTO>(result);
            return redata;
        }
    }
}
