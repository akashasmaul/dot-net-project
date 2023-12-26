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
