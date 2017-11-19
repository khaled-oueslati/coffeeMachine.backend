using CoffeMachineDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.backend.Tests
{
    class TestOrderDbSet : TestDbSet<Order>
    {
        public override Order Find(params object[] keyValues)
        {
            return this.SingleOrDefault(order => order.Id == (int)keyValues.Single());
        }
    }

    class TestOrderTypesDbSet : TestDbSet<OrderType>
    {
        public override OrderType Find(params object[] keyValues)
        {
            return this.SingleOrDefault(orderType => orderType.Id == (int)keyValues.Single());
        }
    }
}
