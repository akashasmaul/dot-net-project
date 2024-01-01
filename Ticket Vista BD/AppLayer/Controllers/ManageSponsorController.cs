using AppLayer.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class ManageSponsorController : ApiController
    {


        //[AdminLogged]
        //[HttpPost]
        //[Route("api/Registration/Sponsor")]
        //public HttpResponseMessage Create(SponsorDTO obj)
        //{
        //    try
        //    {
        //        var data = SponsorService.Create(obj);
        //        if (data)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Registered Successfully", Data = obj });
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Registered", Data = obj });
        //        }
        //    }
        //    catch (DbUpdateException dbEx)
        //    {
        //        Exception innerException = dbEx.InnerException;
        //        while (innerException.InnerException != null)
        //            innerException = innerException.InnerException;
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = innerException.Message, Data = obj });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
        //    }
        //}


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/getSponsors")]
        public HttpResponseMessage GetSponsor()
        {
            try
            {
                var data = SponsorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }



        [AdminLogged]
        [HttpGet]
        [Route("api/admin/getSponsor/{id}")]
        public HttpResponseMessage GetSponsor(int id)
        {
            try
            {
                var data = SponsorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }


        [AdminLogged]
        [HttpPost]
        [Route("api/admin/UpdateSponsor")]
        public HttpResponseMessage UpdateSponsor(SponsorUpdateDTO obj)
        {
            try
            {
                var data = SponsorService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated Succesfully", Data = obj });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }

        }


        [AdminLogged]
        [HttpGet]
        [Route("api/admin/DeleteSponsor/{id}")]
        public HttpResponseMessage DeleteSponsor(int id)
        {
            try
            {
                var data = SponsorService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }
    }
}
