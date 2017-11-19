using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoffeMachineDAL.Managers;
using CoffeMachineDAL;
using CoffeMachineDAL.Model;
using CoffeeMachine.backend.Dto;
using System.Web.Http.Cors;

namespace CoffeeMachine.backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {
        private OrdersManager _orderManager ;

        public OrdersController()
        {
            _orderManager = new OrdersManager();
        }

        public OrdersController(OrdersManager orderManager)
        {
            _orderManager = orderManager;
        }
        // GET: api/orders/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Order order = _orderManager.getById(id);
                return Ok(new SuccessDTO<Order>(order));
            }
            catch (Exception)
            {
                //return Ok(new FailureDTO<ErrorMessageDTO>(new ErrorMessageDTO() { Message = "Not found Error" }));
                return NotFound();

            }
        }

        [Route("api/orders/user/{id}")]
        public IHttpActionResult GetOrderByUserId(int id)
        {
            try
            {
                Order order = _orderManager.getByUserId(id);
                return Ok(new SuccessDTO<Order>(order));
            }
            catch (Exception)
            {
                //return Ok(new FailureDTO<ErrorMessageDTO>(new ErrorMessageDTO() { Message = "Inexistant User" }));
                return NotFound();

            }
        }

        // POST: api/orders
        public IHttpActionResult Post([FromBody]Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(!order.UserId.Equals(0))
                        _orderManager.save(order);

                    return Ok(new SuccessDTO<Order>(order));
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                return Ok(new FailureDTO<ErrorMessageDTO>(new ErrorMessageDTO() { Message = "Something is Wrong, Please verify your input data" }));
            }
            
        }

        // PUT: api/orders/5
        public IHttpActionResult Put(int id, [FromBody]Order order)
        {
            
            try
            {
                if (id != order.Id)
                    throw (new Exception());
                if (order.Id == 0)
                {
                    order.Id = id;
                }
                if (ModelState.IsValid)
                {
                    if (!order.UserId.Equals(0))
                        _orderManager.Update(order);

                    return Ok(new SuccessDTO<Order>(order));
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                //throw;
                return Ok(new FailureDTO<ErrorMessageDTO>(new ErrorMessageDTO() { Message = "Something is Wrong, Please verify your input data" }));
            }
        }

        // DELETE: api/orders/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _orderManager.Delete(id);
                return Ok(new SuccessDTO<int>(id));                
            }
            catch (Exception)
            {
                return Ok(new FailureDTO<ErrorMessageDTO>(new ErrorMessageDTO() { Message = "Inexistant Order" }));

            }
        }

        [Route("api/orders/save")]
        [HttpPost]
        public IHttpActionResult SaveOrUpdateOrder([FromBody]Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!order.UserId.Equals(0))
                        _orderManager.addOrUpdate(order);

                    return Ok(new SuccessDTO<Order>(order));
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                //throw;
                return Ok(new FailureDTO<ErrorMessageDTO>(new ErrorMessageDTO() { Message = "Something is Wrong, Please verify your input data" }));
            }
        }
    }
}
