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
    public class EmployeeManageController : ApiController
    {
        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/manage/ViewAllClient")]

        public HttpResponseMessage GetClients()
        {
            try
            {
                var data = AdvertiserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, });
            }

        }
    }
}
