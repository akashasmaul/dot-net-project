using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class TCVContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BuyerProfile> BuyerProfiles { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public DbSet<AdminProfile> AdminProfiles { get; set; }
        public DbSet<AdvertiserProfile> AdvertiserProfiles { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Advertise> Advertises { get; set;}


    }
}
