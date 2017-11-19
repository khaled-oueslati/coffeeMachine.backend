using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine.backend.Controllers;
using CoffeeMachine.backend.Dto;
using CoffeMachineDAL.Managers;
using CoffeMachineDAL.Model;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace CoffeeMachine.backend.Tests
{
    [TestClass]
    public class OrdersUnitTest
    {
        [TestMethod]
        public void PostOrder_ShouldReturnSameOrder()
        {
            var controller = new OrdersController(new OrdersManager(new TestCoffeeContext()));

            var order = getOrderDemo();

            var result = controller.Post(order) as OkNegotiatedContentResult<SuccessDTO<Order>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Response.UserId, order.UserId);
            Assert.AreEqual(result.Content.status, DTOStatus.SUCCESS);
        }


        [TestMethod]
        public void PutOrder_ShouldReturnSameOrder()
        {
            var controller = new OrdersController(new OrdersManager(new TestCoffeeContext()));

            var order = getOrderDemo();

            var result = controller.Put(1, order) as OkNegotiatedContentResult<SuccessDTO<Order>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.status, DTOStatus.SUCCESS);
            Assert.AreEqual(result.Content.Response.UserId, order.UserId);
        }

        [TestMethod]
        public void PutOrder_ShouldFail_WhenDifferentID()
        {
            var controller = new OrdersController(new OrdersManager(new TestCoffeeContext()));

            var order = getOrderDemo();

            var result = controller.Put(10, order) as OkNegotiatedContentResult<FailureDTO<ErrorMessageDTO>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.status, DTOStatus.FAILURE);
        }

        [TestMethod]
        public void GetOrderById_ShouldReturn_Order()
        {
            var context = new OrdersManager(new TestCoffeeContext());
            var controller = new OrdersController(context);
            var orders = getListOrderDemo();
            context.save(orders[0]);
            context.save(orders[1]);
            context.save(orders[2]);

            var result = controller.Get(1) as OkNegotiatedContentResult<SuccessDTO<Order>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Response.Id);
            Assert.AreEqual(DTOStatus.SUCCESS, result.Content.status);
        }

        [TestMethod]
        public void GetOrderByUserId_ShouldReturn_Order()
        {
            var context = new OrdersManager(new TestCoffeeContext());
            var controller = new OrdersController(context);
            var orders = getListOrderDemo();
            context.save(orders[0]);
            context.save(orders[1]);
            context.save(orders[2]);

            var result = controller.GetOrderByUserId(54) as OkNegotiatedContentResult<SuccessDTO<Order>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(54, result.Content.Response.UserId);
            Assert.AreEqual(DTOStatus.SUCCESS, result.Content.status);
        }

        [TestMethod]
        public void GetOrderByUserId_ShouldReturn_NotFound()
        {
            var context = new OrdersManager(new TestCoffeeContext());
            var controller = new OrdersController(context);
            var orders = getListOrderDemo();
            context.save(orders[0]);
            context.save(orders[1]);
            context.save(orders[2]);

            var result = controller.GetOrderByUserId(100);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void DeleteOrder_ShouldReturnOK()
        {
            var context = new OrdersManager(new TestCoffeeContext());
            var controller = new OrdersController(context);
            var item = getOrderDemo();
            context.save(item);

            var result = controller.Delete(1) as OkNegotiatedContentResult<SuccessDTO<int>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Response);
            Assert.AreEqual(DTOStatus.SUCCESS, result.Content.status);
        }


        public Order getOrderDemo()
        {
            return new Order() { Id = 1, SugarQuantity = 1, SelfMug = false, UserId = 22, Type = new OrderType() {Id=1,Label="Coffee" } ,OrderTypeId = 1};
        }

        public List<Order> getListOrderDemo()
        {
            return new List<Order>()
            {
                new Order() { Id = 1, SugarQuantity = 1, SelfMug = false, UserId = 22, OrderTypeId = 1} ,
                new Order() { Id = 2, SugarQuantity = 2, SelfMug = false, UserId = 54, OrderTypeId = 2} ,
                new Order() { Id = 3, SugarQuantity = 0, SelfMug = false, UserId = 20, OrderTypeId = 2} 
            };
        }
    }
}
