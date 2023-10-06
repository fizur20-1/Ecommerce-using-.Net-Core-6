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
    public class AuthService
    {
        internal static string globalUsername;
        public static TokenDTO Authenticate1(string email, string password)
        {

            var result = DataAccessFactory.AuthData().Authenticate(email, password);
            if (result)
            {
                var token = new Token();
                token.Email = email;
                token.CreatedAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString().Substring(1, 10);
                globalUsername = token.Email;

                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);

                    if (IsCustomer(token.TKey) )
                    {
                        return mapper.Map<TokenDTO>(ret);
                    }

                    
                }
            }
            return null;
        }

        public static string Check()
        {
            return globalUsername;
        }

        public static bool IsTokenValid(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (existingToken != null && existingToken.DeletedAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            existingToken.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(existingToken) != null)
            {
                return true;
            }
            return false;
        }

        public static bool IsCustomer(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (IsTokenValid(TKey) && existingToken.User.Role.Equals("Customer")
                && existingToken.Email == DataAccessFactory.UserData().Get(globalUsername).Email)
            {
                return true;
            }
            return false;
        }
    }
}
