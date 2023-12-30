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
    public class AdvertiseService
    {
        public static bool Create(AdvertiseCreateDTO obj ,int id)
        {
            var data = new Advertise();
            data.AdvertiserId = id;
            data.Title = obj.Title; 
            data.Description = obj.Description;
            data.TicketPrice = obj.TicketPrice;
            data.Status = "Pending";
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdvertiseCreateDTO, Advertise>();
                c.CreateMap<AdvertiseCreateDTO, AdvertiseDTO>();

            });
            var mapper = new Mapper(cfg);
            var advertise = mapper.Map<Advertise>(data);

            var result = DataAccessFactory.AdvertiseData().Create(advertise);

            return result;
        }
    }
}
