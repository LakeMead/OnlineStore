namespace OnlineStore.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineStoreDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineStoreDbContext context)
        {
            if (!context.Products.Any() || !context.Categories.Any())
            {
                // CATEGORIES
                var cat1 = new Category { Name = "Accessories", Order = 1 };
                var cat2 = new Category { Name = "DIY", Order = 3 };
                var cat3 = new Category { Name = "Tools", Order = 2 };

                context.Categories.AddOrUpdate(cat1, cat2, cat3);

                // COLORS
                var color1 = new Color { Name = "White" };
                var color2 = new Color { Name = "Black" };
                var color3 = new Color { Name = "Red" };
                var color4 = new Color { Name = "Green" };
                var color5 = new Color { Name = "Blue" };
                var color6 = new Color { Name = "Yellow" };

                context.Colors.AddOrUpdate(color1, color2, color3, color4, color5, color6);
                context.SaveChanges();

                // PRODUCTS
                var product1 = new Product
                {
                    Name = "Arduino UNO Rev3",
                    Description =
                        "The Arduino UNO R3 is a microcontroller board based on the ATmega328. It has 14 digital input/output pins (of which 6 can be used as PWM outputs), 6 analog inputs, a 16 MHz crystal oscillator, a USB connection, a power jack, an ICSP header, and a reset button. It contains everything needed to support the microcontroller; simply connect it to a computer with a USB cable or power it with a AC-to-DC adapter or battery to get started.",
                    Price = 12.40m,
                    Quantity = 1,
                    CategoryId = cat2.Id,
                    ImagePath = null,
                    Colors = new List<Color>()
                    {
                        color1, 
                        color6
                    }
                };

                var product2 = new Product
                {
                    Name = "Arduino Leonardo with Headers",
                    Description =
                        "The Arduino Leonardo is a microcontroller board based on the ATmega32u4. It has 20 digital input/output pins (of which 7 can be used as PWM outputs and 12 as analog inputs), a 16 MHz crystal oscillator, a micro USB connection, a power jack, an ICSP header, and a reset button. It contains everything needed to support the microcontroller; simply connect it to a computer with a USB cable or power it with a AC-to-DC adapter or battery to get started.",
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
                    Name = "A13-OLinuXino",
                    Description =
                        "The default A13-OLinuXino image is set for a VGA display and 800x600 resolution. To use LCD with A13-OLinuXino you need to upload a new image with the appropriate settings. The download links for the images may be found in the wiki article for A13-OLinuXino: https://www.olimex.com/wiki/A13-OLinuXino",
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
                        "The Raspberry Pi is a low cost, credit-card sized computer that plugs into a computer monitor or TV, and uses a standard keyboard and mouse. It is a capable little device that enables people of all ages to explore computing, and to learn how to program in languages like Scratch and Python.",
                    Price = 131.44m,
                    Quantity = 150,
                    CategoryId = cat1.Id,
                    ImagePath = null,
                };

                var product5 = new Product
                {
                    Name = "Generic AC Adapter For Acer",
                    Description =
                        "Features & Specifications: Ablegrid® Brand Replacement Product!!! Same Day Shipping from USA! 100% Brand New, High Quality Power Charger/Adapter ( Non-OEM ) Input Voltage: AC 100V--240V Input Frequency : 50-60Hz Output Voltage:12V 2A Connecter Size:Round tip",
                    Price = 351.44m,
                    Quantity = 5,
                    CategoryId = cat1.Id,
                    ImagePath = null,
                };

                var product6 = new Product
                {
                    Name = "hello kitty phone case",
                    Description =
                        "[HELLO KITTY] Armor cell phone case For iPhone 6/6 plus fit 4.7/5.5 inch. water/dirt/shock proof",
                    Price = 1.47m,
                    Quantity = 23,
                    CategoryId = cat1.Id,
                    ImagePath = null,
                };

                context.Products.AddOrUpdate(product1);
                context.Products.AddOrUpdate(product2);
                context.Products.AddOrUpdate(product3);
                context.Products.AddOrUpdate(product4);
                context.Products.AddOrUpdate(product5);
                context.Products.AddOrUpdate(product6);
                context.SaveChanges();


                // LABELS
                var label1 = new Label
                {
                    Content = "Electronics",
                    Products = new List<Product>()
                    {
                        product4, product1, product5, product2
                    }
                };

                var label2 = new Label
                {
                    Content = "Gadgets",
                    Products = new List<Product>()
                    {
                        product2, product3, product5
                    }
                };

                context.Labels.AddOrUpdate(label1, label2);
                context.SaveChanges();


                // USERS
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                var user1 = new User
                {
                    CreatedOn = DateTime.Now,
                    UserName = "Pesho",
                    Address = "Sofia",
                    Email = "user1@gmail.com",
                    FirstName = "Pesho",
                    LastName = "Peshov",
                };

                var userCreateResult1 = userManager.Create(user1, "Az-123456");
                if (userCreateResult1.Succeeded)
                {
                    context.Users.AddOrUpdate(user1);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult1.Errors));
                }

                var user2 = new User
                {
                    CreatedOn = DateTime.Now,
                    UserName = "Gosho",
                    Address = "Sofia",
                    Email = "user2@gmail.com",
                    FirstName = "Gosho",
                    LastName = "Goshov",
                };

                var userCreateResult2 = userManager.Create(user2, "Az-123456");
                if (userCreateResult2.Succeeded)
                {
                    context.Users.AddOrUpdate(user2);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult2.Errors));
                }


                // ORDERS
                var order1 = new Order
                {
                    CreatedOn = DateTime.Now,
                    OrderStatus = OrderStatus.Approved,
                    Products = new List<Product>
                    {
                        product1, product2, product3
                    },
                    UserId = user1.Id
                };

                var order2 = new Order
                {
                    CreatedOn = DateTime.Now,
                    OrderStatus = OrderStatus.Approved,
                    Products = new List<Product>
                    {
                        product1, product5
                    },
                    UserId = user2.Id
                };

                context.Orders.AddOrUpdate(order1);
                context.Orders.AddOrUpdate(order2);


                // RATINGS
                var rating1 = new Rating
                    {
                        Type = RatingType.Excellent,
                        Author = context.Users.FirstOrDefault(u => u.FirstName == "Pesho"),
                        ProductId = 1
                    };

                var rating2 = new Rating
                {
                    Type = RatingType.VeryBad,
                    Author = context.Users.FirstOrDefault(u => u.FirstName == "Gosho"),
                    ProductId = 1
                };

                var rating3 = new Rating
                {
                    Type = RatingType.VeryGood,
                    Author = context.Users.FirstOrDefault(u => u.FirstName == "Gosho"),
                    ProductId = 5
                };

                context.Ratings.AddOrUpdate(rating1);
                context.Ratings.AddOrUpdate(rating2);
                context.Ratings.AddOrUpdate(rating3);


                // DISCOUNTS
                var discount1 = new Discount
                                {
                                    Percent = 50,
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(7),
                                    Products = new List<Product> { product1, product2 }
                                };

                var discount2 = new Discount
                {
                    Percent = 20,
                    StartDate = DateTime.Now.AddDays(5),
                    EndDate = DateTime.Now.AddDays(10),
                    Products = new List<Product> { product3 }
                };

                context.Discounts.AddOrUpdate(discount1);
                context.Discounts.AddOrUpdate(discount2);


                context.SaveChanges();
            }
        }
    }
}
