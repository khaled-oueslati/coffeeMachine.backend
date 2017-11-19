using CoffeMachineDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachineDAL.Managers
{
    public class OrderTypeManager
    {
        private ICoffeeContext _coffeMachineContext;

        public OrderTypeManager()
        {
            _coffeMachineContext = new CoffeeMachineDataContext();
        }

        public OrderTypeManager(ICoffeeContext context)
        {
            _coffeMachineContext = context;
        }
        public ICollection<OrderType> getAll()
        {
            return _coffeMachineContext.OrderTypes.ToList();
        }

        public OrderType getById(int id)
        {
            return _coffeMachineContext.OrderTypes.Where(o => o.Id.Equals(id)).FirstOrDefault<OrderType>();
        }
    }
}
