using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IAuth<bool> BuyerAuthData()
        {
            return new BuyerRepo();
        }
        public static IAuth<bool> AdminAuthData()
        {
            return new AdminRepo();
        }
        public static IAuth<bool> EmployeeAuthData()
        {
            return new EmployeeRepo();
        }
        public static IAuth<bool> AdvertiserAuthData()
        {
            return new AdvertiserRepo();
        }

        public static IRepo<Token,String,Token> TokenData()
        { 
            return new TokenRepo();
        }
        public static IRepo<Buyer,int,bool> BuyerData()
        {
            return new BuyerRepo();
        }

        public static IRepo<Advertiser, int, bool> AdvertiserData()
        {
            return new AdvertiserRepo();
        }

        public static IRepo<Admin, int, bool> AdminData()
        {
            return new AdminRepo();
        }


        public static IRepo<Employee, int, bool> EmployeeData()
        {
            return new EmployeeRepo();
        }
    }
}
