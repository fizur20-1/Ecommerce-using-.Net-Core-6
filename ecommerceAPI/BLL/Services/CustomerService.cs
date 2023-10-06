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
    public class CustomerService
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomerDTO>>(data);
            return mapped;
        }

        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;
        }

        public static CustomerDTO Create(CustomerDTO obj) // Need To Be Sure About This
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Customer>(obj);
            var result = DataAccessFactory.CustomerData().Create(data);
            var redata = mapper.Map<CustomerDTO>(result);
            return redata;
        }

        public static bool Delete(int Id)
        {
           
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = DataAccessFactory.CustomerData().Delete(Id);
            return data;
        }

        public static CustomerDTO Update(CustomerDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Customer>(obj);
            var result = DataAccessFactory.CustomerData().Update(data);
            var redata = mapper.Map<CustomerDTO>(result);
            return redata;
        }
    }
}

