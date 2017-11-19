using CoffeMachineDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachineDAL.Managers
{
    public class OrdersManager
    {
        private ICoffeeContext _coffeMachineContext;

        public OrdersManager()
        {
            _coffeMachineContext = new CoffeeMachineDataContext();
        }

        public OrdersManager(ICoffeeContext context)
        {
            _coffeMachineContext = context;
        }

        public Order getById(int id)
        {
            return _coffeMachineContext.Orders.Where(o => o.Id.Equals(id)).First<Order>();
        }

        public Order getByUserId(int userId)
        {
            return _coffeMachineContext.Orders.Where(o => o.UserId.Equals(userId)).First<Order>();
        }

        public void save(Order order)
        {
            _coffeMachineContext.Orders.Add(order);
            _coffeMachineContext.SaveChanges();
        }

        public void Update(Order order)
        {
            if (order.Id != 0)
            {
                _coffeMachineContext.Orders.Attach(order);
                _coffeMachineContext.MarkAsModified(order);
                _coffeMachineContext.SaveChanges();
                
            }
        }

        public void Delete(Order order)
        {
            _coffeMachineContext.Orders.Remove(order);
        }
        public void Delete(int orderId)
        {
            Order order = new Order() { Id = orderId };
            _coffeMachineContext.Orders.Attach(order);
            _coffeMachineContext.Orders.Remove(order);
            _coffeMachineContext.SaveChanges();
        }

        public Order addOrUpdate(Order order)
        {
            
            if (order.Id != 0)
            {
                _coffeMachineContext.Orders.Attach(order);
                _coffeMachineContext.MarkAsModified(order);
            }
            else
            {
                _coffeMachineContext.Orders.Add(order);
            }

            _coffeMachineContext.SaveChanges();
            //_coffeMachineContext.Ent
            return order;
        }
    }
}
