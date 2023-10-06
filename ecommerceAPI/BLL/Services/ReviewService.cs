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
    public class ReviewService
    {
        public static List<ReviewDTO> Get()
        {
            var data = DataAccessFactory.ReviewData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ReviewDTO>>(data);
            return mapped;
        }

        public static ReviewDTO Get(int id)
        {
            var data = DataAccessFactory.ReviewData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ReviewDTO>(data);
            return mapped;
        }

        public static ReviewDTO Create(ReviewDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
                c.CreateMap<ReviewDTO, Review>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Review>(obj);
            var result = DataAccessFactory.ReviewData().Create(data);
            var redata = mapper.Map<ReviewDTO>(result);
            return redata;
        }

        public static bool Delete(int Id)
        {
            
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = DataAccessFactory.ReviewData().Delete(Id);
            return data;
        }

        public static ReviewDTO Update(ReviewDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
                c.CreateMap<ReviewDTO, Review>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Review>(obj);
            var result = DataAccessFactory.ReviewData().Update(data);
            var redata = mapper.Map<ReviewDTO>(result);
            return redata;
        }
    }
}

