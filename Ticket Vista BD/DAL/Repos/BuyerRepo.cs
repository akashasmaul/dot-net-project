using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BuyerRepo : Repo, IRepo<Buyer, int, bool> ,IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Buyers.FirstOrDefault(u=>u.UserName.Equals(username) && u.Password.Equals(password)); 
            if(data != null) return true;
            return false;
        }

        public bool Create(Buyer obj)
        {
            db.Buyers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Read(id);
            db.Buyers.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Buyer> Read()
        {
            return db.Buyers.ToList();
        }

        public Buyer Read(int id)
        {
            return db.Buyers.Find(id);
        }

        public bool Update(Buyer obj)
        {
            var data = db.Buyers.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
