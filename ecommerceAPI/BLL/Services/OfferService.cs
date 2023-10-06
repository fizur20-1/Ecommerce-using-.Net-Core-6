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
    public class OfferService
    {
        public static List<OfferDTO> Get()
        {
            var data = DataAccessFactory.OfferData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Offer, OfferDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OfferDTO>>(data);
            return mapped;
        }

        public static OfferDTO Get(int id)
        {
            var data = DataAccessFactory.OfferData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Offer, OfferDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OfferDTO>(data);
            return mapped;
        }

        public static OfferDTO Create(OfferDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Offer, OfferDTO>();
                c.CreateMap<OfferDTO, Offer>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Offer>(obj);
            var result = DataAccessFactory.OfferData().Create(data);
            var redata = mapper.Map<OfferDTO>(result);
            return redata;
        }

        public static bool Delete(int Id)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Offer, OfferDTO>();
            });
            var mapper = new Mapper(cfg);

            var data = DataAccessFactory.OfferData().Delete(Id);
            return data;
        }

        public static OfferDTO Update(OfferDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Offer, OfferDTO>();
                c.CreateMap<OfferDTO, Offer>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Offer>(obj);
            var result = DataAccessFactory.OfferData().Update(data);
            var redata = mapper.Map<OfferDTO>(result);
            return redata;
        }
    }
}
