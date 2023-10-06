using AutoMapper;
using DAL.Models;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }

        public static UserDTO Get(string Email)
        {
            var data = DataAccessFactory.UserData().Get(Email);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }
        public static UserDTO Delete(string Email)
        {
            var data = DataAccessFactory.UserData().Delete(Email);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }

        public static UserDTO Update(UserDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<User>(obj);
            var result = DataAccessFactory.UserData().Update(data);
            var redata = mapper.Map<UserDTO>(result);
            return redata;
        }
    }
}
