using CoffeMachineDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachineDAL
{
    public interface ICoffeeContext : IDisposable
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderType> OrderTypes { get; set; }

        int SaveChanges();
        void MarkAsModified<TEntity>(TEntity item) where TEntity : class;
    }
}
