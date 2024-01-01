﻿using AppLayer.Auth;
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
    public class SponsorController : ApiController
    {
        [HttpPost]
        [Route("api/Registration/Sponsor")]
        public HttpResponseMessage Create(SponsorDTO obj)
        {
            try
            {
                var data = SponsorService.Create(obj);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Registered Successfully", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Registered", Data = obj });
                }
            }
            catch (DbUpdateException dbEx)
            {
                Exception innerException = dbEx.InnerException;
                while (innerException.InnerException != null)
                    innerException = innerException.InnerException;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = innerException.Message, Data = obj });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }
        }

        [SponsorLogged]
        [HttpGet]
        [Route("api/sponsor/ViewProfile/{id}/{Token}")]
        public HttpResponseMessage ViewProfile(int id, string Token)
        {
            try
            {
                if (AuthService.ValidUser(Token, id))
                {

                    var data = SponsorService.UnprotectedGet(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Wrong Token or Id" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

        [SponsorLogged]
        [HttpGet]
        [Route("api/sponsor/getSponsors")]
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

        [SponsorLogged]
        [HttpPut]
        [Route("api/sponsor/updateProfile")]
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

        [SponsorLogged]
        [HttpDelete]
        [Route("api/sponsor/DeleteSponsor/{id}")]
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

        [SponsorLogged]
        [HttpPatch]
        [Route("api/sponsor/updatePassword")]
        public HttpResponseMessage UpdatePass(SponsorUpdatePasswordDTO obj)
        {
            try
            {
                var data = SponsorService.UpdatePass(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Password Updated Succesfully"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message});
            }

        }


        [SponsorLogged]
        [HttpGet]
        [Route("api/sponsor/viewEvents")]
        public HttpResponseMessage ViewEvents()
        {
            try
            {
                var data = EventService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });

            }
        }

            //[SponsorLogged]
            //[HttpPost]
            //[Route("api/sponsor/addEvent")]
            //public HttpResponseMessage Create(EventDTO obj)
            //{
            //    try
            //    {
            //        var data = EventService.Create(obj);
            //        if (data)
            //        {
            //            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Event Added", Data = obj });
            //        }
            //        else
            //        {
            //            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error", Data = obj });
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

        [SponsorLogged]
        [HttpGet]
        [Route("api/sponsor/getEvent/{id}")]
        public HttpResponseMessage GetEvent(int id)
        {
            try
            {
                var data = EventService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }

    }

    }

