using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.Common.Enumerations;

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

            if (!context.Products.Any() || !context.Categories.Any())
            {
                var cat1 = new Category { Name = "Accessories", Order = 1 };
                var cat2 = new Category { Name = "DIY", Order = 3 };
                var cat3 = new Category { Name = "Tools", Order = 2 };

                context.Categories.AddOrUpdate(cat1, cat2, cat3);

                var color1 = new Color { Name = "White" }; 
                var color2 = new Color { Name = "Black" };
                var color3 = new Color { Name = "Red" };
                var color4 = new Color { Name = "Green" };
                var color5 = new Color { Name = "Blue" } ;
                var color6 = new Color { Name = "Yellow" };

                context.Colors.AddOrUpdate(color1, color2, color3, color4, color5, color6);

                context.SaveChanges();

                var product1 = new Product
                {
                    Name = "Arduino",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Price = 12.40m,
                    Quantity = 1,
                    CategoryId = cat2.Id,
                    ImagePath = null,
                    Colors = new List<Color>()
                    {
                        color1, color6
                    }
                };


                var product2 = new Product
                {
                    Name = "Arduino Uno",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Price = 10.40m,
                    Quantity = 10,
                    CategoryId = cat2.Id,
                    ImagePath = null,
                    Colors = new List<Color>()
                    {
                        color2, color3
                    }
                };

                var product3 = new Product
                {
                    Name = "OLinuXino",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Price = 33.94m,
                    Quantity = 100,
                    CategoryId = cat2.Id,
                    ImagePath = null,
                    Colors = new List<Color>()
                    {
                        color4, color3
                    }
                };

                var product4 = new Product
                {
                    Name = "Raspeberry Pi",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Price = 31.44m,
                    Quantity = 50,
                    CategoryId = cat1.Id,
                    ImagePath = null,
                };

                context.Products.AddOrUpdate(product1);
                context.Products.AddOrUpdate(product2);
                context.Products.AddOrUpdate(product3);
                context.Products.AddOrUpdate(product4);

                var label1 = new Label
                {
                    Content = "Electronics",
                    Products = new List<Product>()
                    {
                        product4, product1
                    }
                };

                var label2 = new Label
                {
                    Content = "Djadji",
                    Products = new List<Product>()
                    {
                        product2, product3
                    }
                };

                context.Labels.AddOrUpdate(label1, label2);
                context.SaveChanges();

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 2,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                var user = new User()
                {
                    CreatedOn = DateTime.Now,
                    UserName = "Pesho",
                    Address = "Sofia",
                    Email = "user@gmail.com",
                    FirstName = "Vladi",
                    LastName = "Ivanov",
                };

                var userCreateResult = userManager.Create(user, "admin");
                if (userCreateResult.Succeeded)
                {
                    context.Users.AddOrUpdate(user);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors));
                }

                var order1 = new Order
                {
                    CreatedOn = DateTime.Now,
                    OrderStatus = OrderStatus.Approved,
                    Products = new List<Product>()
                    {
                        product1, product2, product3
                    },
                    UserId = user.Id
                };

                context.Orders.AddOrUpdate(order1);

                context.SaveChanges();
            }
        }
    }
}
