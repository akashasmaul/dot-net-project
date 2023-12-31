using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketService
    {
        public static bool Create(TicketDTO ticket)
        {
  
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TicketDTO, Ticket>();
            });
            var mapper = new Mapper(cfg);
            var Ticket = mapper.Map<Ticket>(ticket);

            var result = DataAccessFactory.TicketData().Create(Ticket);

            return result;
        }

        public static int CountTicket()
        {
            return DataAccessFactory.TicketData().Count();
        }

        public static bool DetateTicket(int id)
        {
            return DataAccessFactory.TicketData().Delete(id);
        }

        public static List<TicketDTO> TicketList()
        {
            var data = DataAccessFactory.TicketData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TicketDTO>>(data);
            return mapped;
        }

        public static TicketDTO GetTicket(int id)
        {
            var data = DataAccessFactory.TicketData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<TicketDTO>(data);
          
        }

        public static bool Update(TicketDTO ticketDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TicketDTO, Ticket>();
            });
            var mapper = new Mapper(cfg);
            var Ticket = mapper.Map<Ticket>(ticketDto);

            return DataAccessFactory.TicketData().Update(Ticket);
        }
    }
}
