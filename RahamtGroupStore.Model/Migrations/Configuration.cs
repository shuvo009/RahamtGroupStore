using RahamtGroupStore.Model.DatabaseModels;
namespace RahamtGroupStore.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RepositoryContext context)
        {
            if (!context.UserAccounts.Any(x => x.UserName.Equals("Admin", StringComparison.CurrentCultureIgnoreCase)))
            {
                context.UserAccounts.AddOrUpdate(new UserAccount
                                                     {
                                                         UserName = "Admin",
                                                         UserPassword = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                                                         ReadOnly = false
                                                     });
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
