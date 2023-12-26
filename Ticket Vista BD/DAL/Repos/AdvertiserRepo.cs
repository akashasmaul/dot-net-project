﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdvertiserRepo : Repo, IRepo<Advertiser, int, bool>, IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {

            var data = db.Advertisers.FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public bool Create(Advertiser obj)
        {
            db.Advertisers.Add(obj);
            return db.SaveChanges() > 0;    
        }

        public bool Delete(int id)
        {
            var data = Read(id);
            db.Advertisers.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Advertiser> Read()
        {
            return db.Advertisers.ToList();
        }

        public Advertiser Read(int id)
        {
            return db.Advertisers.Find(id);
        }

        public bool Update(Advertiser obj)
        {
            var data = db.Advertisers.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
