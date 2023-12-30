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
            throw new NotImplementedException();
        }

        public bool Create(Ticket obj)
        {
            var evnt = db.Events.Find(obj.Id);
            var tkt = new Ticket(); 
            tkt.Title = evnt.Title;
            tkt.TicketQuantity =obj.TicketQuantity;
            tkt.CreatedDate = DateTime.Now;
            tkt.TotalPrice = obj.TicketQuantity*evnt.TicketPrice;
            tkt.BuyerId = obj.BuyerId;
            db.Tickets.Add(tkt);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> Read()
        {
            throw new NotImplementedException();
        }

        public Ticket Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket obj)
        {
            throw new NotImplementedException();
        }
    }
}
