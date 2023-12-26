using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var buyer = DataAccessFactory.BuyerAuthData().Authenticate(username, password);
            var admin = DataAccessFactory.AdminAuthData().Authenticate(username, password);
            var employee = DataAccessFactory.EmployeeAuthData().Authenticate(username, password);
            var advertiser = DataAccessFactory.AdvertiserAuthData().Authenticate(username, password);

            if (buyer)
            {
                var token = new Token();
                token.Username = username;
                token.CreatedAt = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();
                token.Type = "Buyer";
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            else if (admin)
            {
                var token = new Token();
                token.Username = username;
                token.CreatedAt = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();
                token.Type = "Admin";
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            else if (employee)
            {

                var token = new Token();
                token.Username = username;
                token.CreatedAt = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();
                token.Type = "Employee";
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            else if (advertiser)
            {
                var token = new Token();
                token.Username = username;
                token.CreatedAt = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();
                token.Type = "Advertiser";
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }

            return null;

        }

       public static bool IsTokenValid(string TokenKey)

       {
            var exToken = DataAccessFactory.TokenData().Read(TokenKey);
            if (exToken != null && exToken.DeletedAt == null)
            {
                return true;
            }
            return false;
       }


        public static bool IsTokenValidForAdmin(string TokenKey)

        {
            var exToken = DataAccessFactory.TokenData().Read(TokenKey);
            if (exToken != null && exToken.DeletedAt == null && exToken.Type =="Admin")
            {
                return true;
            }
            return false;
        }

        public static bool IsTokenValidForEmployee(string TokenKey)

        {
            var exToken = DataAccessFactory.TokenData().Read(TokenKey);
            if (exToken != null && exToken.DeletedAt == null && exToken.Type == "Employee")
            {
                return true;
            }
            return false;
        }

        public static bool IsTokenValidForBuyer(string TokenKey)

        {
            var exToken = DataAccessFactory.TokenData().Read(TokenKey);
            if (exToken != null && exToken.DeletedAt == null && exToken.Type == "Buyer")
            {
                return true;
            }
            return false;
        }


        public static bool IsTokenValidForAdvertiser(string TokenKey)

        {
            var exToken = DataAccessFactory.TokenData().Read(TokenKey);
            if (exToken != null && exToken.DeletedAt == null && exToken.Type == "Advertiser")
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string TokenKey)
        {
            var exToken = DataAccessFactory.TokenData().Read(TokenKey);
            exToken.DeletedAt = DateTime.Now;
           if( DataAccessFactory.TokenData().Update(exToken) != null ) 
            {
                return true;
            }
           return false;
           
        }


    }
}
