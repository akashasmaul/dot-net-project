using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SponsorService
    {
        public static List<SponsorViewDTO> Get()
        {
            var data = DataAccessFactory.SponsorData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sponsor, SponsorViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SponsorViewDTO>>(data);
            return mapped;
        }

        public static SponsorViewDTO Get(int id)
        {
            var data = DataAccessFactory.SponsorData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sponsor, SponsorViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SponsorViewDTO>(data);
            return mapped;
        }
        public static SponsorDTO UnprotectedGet(int id)
        {
            var data = DataAccessFactory.SponsorData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sponsor, SponsorDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SponsorDTO>(data);
            return mapped;
        }
        public static bool Create(SponsorDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SponsorDTO, Sponsor>();
            });
            var mapper = new Mapper(cfg);
            var sponsor = mapper.Map<Sponsor>(obj);

            var result = DataAccessFactory.SponsorData().Create(sponsor);

            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.SponsorData().Delete(id);

        }
        public static bool Update(SponsorUpdateDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SponsorUpdateDTO, Sponsor>();
            });
            var mapper = new Mapper(cfg);
            var sponsor = mapper.Map<Sponsor>(obj);

            var result = DataAccessFactory.SponsorData().Update(sponsor);

            return result;
        }
        public static bool UpdatePass(SponsorUpdatePasswordDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SponsorUpdatePasswordDTO, Sponsor>();
            });
            var mapper = new Mapper(cfg);
            var sponsor = mapper.Map<Sponsor>(obj);

            var result = DataAccessFactory.SponsorPassChange().UpdatePass(sponsor);

            return result;
        }

    }
}
