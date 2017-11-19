using CoffeMachineDAL;
using CoffeMachineDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.backend.Tests
{
    public class TestCoffeeContext : ICoffeeContext
    {
        public TestCoffeeContext()
        {
            this.Orders = new TestOrderDbSet();
            this.OrderTypes = new TestOrderTypesDbSet();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified<TEntity>(TEntity item) where TEntity : class { }
        public void Dispose() { }
    }
}
