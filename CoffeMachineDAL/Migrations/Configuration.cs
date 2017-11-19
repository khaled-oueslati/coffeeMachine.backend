namespace CoffeMachineDAL.Migrations
{
    using CoffeMachineDAL.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeMachineDAL.CoffeeMachineDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoffeMachineDAL.CoffeeMachineDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.OrderTypes.AddOrUpdate(x=> x.Id,
            new OrderType() {Id=1,Label="Coffee"},
            new OrderType() {Id=2,Label="Tea"},
            new OrderType() {Id=3,Label="Chocolate"}
                );
        }
    }
}
