using CoffeeMachine.backend.Dto;
using CoffeMachineDAL.Managers;
using CoffeMachineDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoffeeMachine.backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderTypesController : ApiController
    {
        private OrderTypeManager _orderTypeManager = new OrderTypeManager();

        // GET: api/OrderTypes
        public IHttpActionResult Get()
        {
            try
            {
                var orderTypes = _orderTypeManager.getAll();
                return Ok(new SuccessDTO<ICollection<OrderType>>(orderTypes));
            }
            catch (Exception)
            {
                throw;
                return Ok(new FailureDTO<ErrorMessageDTO>(new ErrorMessageDTO() { Message = "Request Failure" }));

            }
        }
    }
}
