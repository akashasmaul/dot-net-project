using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TicketRepo : Repo, IRepo<Ticket, int, bool>
    {
        public int Count()
        {
            return db.Tickets.Count();
        }

        public bool Create(Ticket obj)
        {

            db.Tickets.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exst = db.Tickets.Find(id);
            db.Tickets.Remove(exst);
            return db.SaveChanges() > 0;
        }

        public List<Ticket> Read()
        {
            return db.Tickets.ToList();
        }

        public Ticket Read(int id)
        {
            return db.Tickets.Find(id);
        }

        public bool Update(Ticket obj)
        {
            var exst = db.Tickets.Find(obj.Id);
            db.Entry(exst).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
