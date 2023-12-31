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
    public class TicketController : ApiController
    {

        [BuyerLogged]
        [HttpPost]
        [Route("api/Buyer/CreateTicket")]
        public HttpResponseMessage Create(TicketDTO obj)
        {
            try
            {

                var data = TicketService.Create(obj);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Ticket Created Successfully", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Created", Data = obj });
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

        [BuyerLogged, HttpGet]
        [Route("api/CountTicket")]
        public HttpResponseMessage Count()
        {
            try
            {
                var data = TicketService.CountTicket();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Tocket Count", Data = data });

            }
            catch (DbUpdateException dbEx)
            {
                Exception innerException = dbEx.InnerException;
                while (innerException.InnerException != null)
                    innerException = innerException.InnerException;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = innerException.Message });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }

        [HttpDelete]
        [Route("api/Ticket/Delete/{id}")]
        public HttpResponseMessage DeleteTicket(int id)
        {
            try
            {
                var result = TicketService.DetateTicket(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Ticket deleted successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Ticket not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Ticket/Update")]
        public HttpResponseMessage Update(TicketDTO ticketDto)
        {
            try
            {
                var result = TicketService.Update(ticketDto);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Ticket updated successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Ticket not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Ticket/Get/{id}")]
        public HttpResponseMessage GetTicket(int id)
        {
            try
            {
                var ticket = TicketService.GetTicket(id);
                if (ticket != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ticket);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Ticket not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Ticket/List")]
        public HttpResponseMessage List()
        {
            try
            {
                var tickets = TicketService.TicketList();
                return Request.CreateResponse(HttpStatusCode.OK, tickets);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }

}
