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
    public class AdvertiserService
    {
        public static List<AdvertiserDTO> Get()
        {
            var data = DataAccessFactory.AdvertiserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertiser, AdvertiserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdvertiserDTO>>(data);
            return mapped;
        }

        public static bool Create(AdvertiserDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdvertiserDTO, Advertiser>();
            });
            var mapper = new Mapper(cfg);
            var advertiser = mapper.Map<Advertiser>(obj);

            var result = DataAccessFactory.AdvertiserData().Create(advertiser);

            return result;
        }

    }
}
