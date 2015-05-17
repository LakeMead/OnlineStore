namespace OnlineStore.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using OnlineStore.Data.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineStoreDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineStoreDbContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////

            context.Categories.Add(new Category { Name = "Accessories" });
            context.Categories.Add(new Category { Name = "DIY" });
            context.Categories.Add(new Category { Name = "Tools" });

            context.Colors.Add(new Color {Name = "White"});
            context.Colors.Add(new Color {Name = "Black"});
            context.Colors.Add(new Color {Name = "Red"});
            context.Colors.Add(new Color {Name = "Green"});
            context.Colors.Add(new Color {Name = "Blue"});
            context.Colors.Add(new Color {Name = "Yellow"});

            context.Products.Add(
                    new Product
                    {
                        Name = "Arduino",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Price = 12.40m,
                        Quantity = 1,
                        CategoryId = 1,
                        ImagePath = null,
                    }
                );

            base.Seed(context);
        }
    }
}
