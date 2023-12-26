using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo ,IRepo<Admin ,int ,bool>, IAuth<bool> 
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Admins.FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public bool Create(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Read(id);
            db.Admins.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Read()
        {
            return db.Admins.ToList();
        }

        public Admin Read(int id)
        {
            return db.Admins.Find(id);
        }

        public bool Update(Admin obj)
        {
            var data = db.Admins.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
