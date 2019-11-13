using ShopDatabaseAdvanced.Model;
using ShopDatabaseAdvanced.Models;
using ShopDatabaseAdvanced.ShopAdvancedDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced
{
    class Program
    {


        static void Main(string[] args)
        {


            using (var db = new AdvancedShopDatabaseContext())
            {
                /*db.Foods.AddRange(groceries);
				db.SaveChanges();
			

				ShoppingCart newCart = new ShoppingCart();
				db.ShoppingCarts.Add(newCart);

                
				ChooseFood(db, newCart);
				while (Console.ReadLine() == "Yes")
				{
					ChooseFood(db, newCart);
				}

				db.SaveChanges();*/

                //	var shoppingCarts = db.ShoppingCarts.Include("Items").ToList();
                /*	foreach(var cart in shoppingCarts)
                    {
                        Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
                        foreach(var food in cart.Items)
                        {
                            Console.WriteLine($"{food.Name} Price: {food.Price}");
                        }
                        Console.WriteLine($"Total: {cart.Sum}");
                    }*/



                //}

                var clients = db.Clients;
                var foods = db.Foods;

                Console.WriteLine("Please enter your first name");
                string firstName = Console.ReadLine();

                Console.WriteLine("Please enter your last name!");
                string lastName = Console.ReadLine();

                Console.WriteLine("Welcome, " + firstName + " " + lastName);

                var client = clients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);



                if (client == null)
                {
                    clients.Add(new Client(firstName, lastName));
                    db.SaveChanges();

                }
                ShoppingCart newCart = new ShoppingCart();
                db.ShoppingCarts.Add(newCart);

                ChooseFood(db, newCart);
                while (Console.ReadLine() == "Yes")
                {
                    ChooseFood(db, newCart);
                }

                db.SaveChanges();

                 //var shoppingCarts = db.ShoppingCarts.Include("Items").ToList();
                foreach (Food food in newCart.Items)
                {
                    Console.WriteLine($"{food.Name} Price: {food.Price}");
                }
                Console.WriteLine($"Total: {newCart.Sum}");

                clients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName).ShoppingCarts.Add(newCart);
                db.SaveChanges();


                var visits = clients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName).ShoppingCarts.Count();

                Console.WriteLine("You have visited shop" + " " + visits + " " + "times!");



                if (visits > 0)
                {
                   
                    Console.WriteLine("Do you want to see your shopping history?");
                    while (Console.ReadLine() == "Yes")
                    {
                        Console.WriteLine("Shopping history below:");
                        var AllCarts = clients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName).ShoppingCarts;
                        foreach (var item in AllCarts)
                        {
                           
                            Console.WriteLine("*****");

                                foreach (var food in item.Items)
                            {
                                Console.WriteLine($"{food.Name} Price: {food.Price}");

                            }
                            Console.WriteLine($"Total:" + item.Sum);

                        }


                        Console.WriteLine("Thanks for shopping. Have a nice day, " + " " + firstName + " " + lastName);

                    }

                }


             

            }

        }

       
            private static void ChooseFood(AdvancedShopDatabaseContext db, ShoppingCart newCart)
            {
                Console.WriteLine("What do you want to buy?");
                string foodName = Console.ReadLine();
                Food chosenFood = db.Foods.FirstOrDefault(x => x.Name == foodName);
                newCart.AddToCart(chosenFood);
                Console.WriteLine("Anything else? Yes/No");
            }


        }
    }


