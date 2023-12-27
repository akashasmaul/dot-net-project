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
    public class EmployeeController : ApiController
    {

        [EmployeeLogged]
        [HttpGet]
        [Route("api/employee/ViewProfile/{id}/{Token}")]
        public HttpResponseMessage ViewProfile(int id, string Token)
        {
            try
            {
                if (AuthService.ValidUser(Token, id))
                {

                    var data = EmployeeService.UnprotectedGet(id);
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

    }
}
