using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SponsorRepo : Repo, IRepo<Sponsor, int, bool>, IAuth<Sponsor>, IPassChng<Sponsor>
    
    {
        public Sponsor Authenticate(string username, string password)
        {

            var data = db.Sponsors.FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(password));
            if (data != null) return data;
            return null;
        }
        public int Count()
        {

            int totalSponsors = db.Sponsors.Count();
            return totalSponsors;
        }

        public bool Create(Sponsor obj)
        {
            db.Sponsors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Read(id);
            db.Sponsors.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Sponsor> Read()
        {
            return db.Sponsors.ToList();
        }

        public Sponsor Read(int id)
        {
            return db.Sponsors.Find(id);
        }

        public bool Update(Sponsor obj)
        {
            var data = db.Sponsors.Find(obj.Id);
            obj.Password = data.Password;
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }


        public bool UpdatePass(Sponsor obj)
        {
            var data = db.Sponsors.Find(obj.Id);
            obj.SponserName = data.SponserName;
            obj.UserName = data.UserName;
            obj.Email = data.Email;
            obj.FirstName = data.FirstName;
            obj.LastName = data.LastName;
            obj.PhoneNumber = data.PhoneNumber;
            obj.Nationality = data.Nationality;
            obj.Address = data.Address;
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
