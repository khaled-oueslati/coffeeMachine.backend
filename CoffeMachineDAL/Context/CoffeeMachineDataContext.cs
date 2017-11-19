using CoffeMachineDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachineDAL
{
    public class CoffeeMachineDataContext : DbContext, ICoffeeContext
    {
        public CoffeeMachineDataContext ()
            :base("CoffeeMachineContext")
        {

        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }

        public void MarkAsModified<TEntity>(TEntity item) where TEntity : class
        {
            Entry(item).State = EntityState.Modified;
        }

    }
}
