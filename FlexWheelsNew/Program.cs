using System;
using System.Collections.Generic;
using System.Linq;
using FlexWheelsNew.Models;

namespace FlexWheelsNew
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to FeeelexWheels Bookingsystem!");
            Console.WriteLine();
            Console.WriteLine("Press any key to move to menu");
            Console.ReadKey();
            MainMenu();
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("0: First time bundle input => 3 bikes and a store");
            Console.WriteLine("1: List all Bookings");
            Console.WriteLine("2: List all customers");
            Console.WriteLine("3: List all bikes");
            Console.WriteLine("4: Create new Customer ==> Booking");
            Console.WriteLine("5: Add a new bicycle");
            Console.WriteLine("6: Add a new store");
            Console.WriteLine("7: Delete bicycle");
            Console.WriteLine("8: Edit Booking");
            Console.WriteLine("9: List all stores");
            Console.WriteLine("10: Delete store");
            Console.WriteLine("11: Delete Booking");
            var menuChoice = Console.ReadLine();

            // Switch case statements for chosing which method to implement
            switch (menuChoice)
            {
                case "1":
                    ShowBookings();
                    break;
                case "2":
                    ShowCustomers();
                    break;
                case "3":
                    ShowBikes();
                    break;
                case "4":
                    AddOrderCust();
                    break;
                case "5":
                    AddBicycle();
                    break;
                case "6":
                    AddStore();
                    break;
                case "7":
                    DeleteBicycle();
                    break;
                case "8":
                    EditBicycle();
                    break;
                case "9":
                    ListStores();
                    break;
                case "10":
                    DeleteStore();
                    break;
                case "11":
                    DeleteBooking();
                    break;
                case "0":
                    AddBundle();
                    break;
            }
        }

        private static void BackToMenu()
        {
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            MainMenu();
        }

        //A method that does whatit says, listing all previously saved bicycles.
        private static void ShowBikes()
        {
            // Declaring a list with bikes
            List<Bicycle> bicycles;

            // Using DB within these brackets
            using (var dbContext = new Database())
            {
                // Retrieving bikes from our DataBase engine and put into a list
                bicycles = dbContext.Bicycle.ToList();
            }

            Console.Clear();
            foreach (var bicycle in bicycles)
            {
                Console.WriteLine($"Bicycle ID: {bicycle.bicycle_id}, Manufacturer: {bicycle.bicycle_brandname}, Wheeltype: {bicycle.wheeltype}, Price/week: {bicycle.bicycleprice}");

            }
            BackToMenu();
        }

        private static void AddStore()
        {
            Console.Clear();
            var store = new Store();

            Console.WriteLine("What is the location of the store?");
            store.StoreLocation = Console.ReadLine();
            using (var DbContext = new Database())
            {
                DbContext.Store.Add(store);
                DbContext.SaveChanges();
            }
            BackToMenu();
        }


    //A method that creates a customer and subsquently a booking 
        private static void AddOrderCust()
        {
            // Creates a new customer and booking
            var order = new Bookings();  
            var cust = new Customer();  
            var bikeOrder = new Bicycle_bookings();

            Console.Clear();

            // Takes input of Customer info
            Console.WriteLine("What is the customers first name?");
            cust.firstname = Console.ReadLine();
            Console.WriteLine("And the last name?");
            cust.lastname = Console.ReadLine();
            Console.WriteLine("On what phone number can we reach the customer?");
            cust.phone_number = Console.ReadLine();
            Console.WriteLine("The Customer's Email");
            cust.email = Console.ReadLine();
            Console.WriteLine("Customer's birthdate 'YYYYMMDDXXXXX' format.");
            cust.SocialSecurityNumber = int.Parse(Console.ReadLine());
            using (var dbContext = new Database())
            {

                dbContext.Customer.Add(cust);
                dbContext.SaveChanges(); //A new customer is now added.

                List<Customer> customers;
                customers = dbContext.Customer.ToList();


                foreach (var customer in customers) //Prints all customers in the database 
                {
                    Console.WriteLine("Here's the list of customers");
                    Console.WriteLine($"Name: {customer.lastname} , {customer.firstname}, CID: {customer.CID}");
                }

                // Customer info is added 

                Console.WriteLine("Now to make a booking, type the CID to attach to a new booking");
                var customerId = int.Parse(Console.ReadLine());
                Console.WriteLine("The date when the booking/order was made (YYYYMMDD).");
                order.rent_date = Console.ReadLine();
                Console.WriteLine("When is the return date of the bike (YYYYMMDD).");
                order.return_date = Console.ReadLine();
                Console.WriteLine("Type in the total ordercost");
                order.price = Console.ReadLine();

                order.Customer = customers.Find(x => x.CID == customerId); // matches the CID from the input with same value in the database.

                dbContext.Bookings.Add(order); // The bookings is added to the database.
                dbContext.SaveChanges(); // Saves the changes made in the database.

                List<Bicycle> bikes;  // laddar alla cyklar
                bikes = dbContext.Bicycle.ToList(); // lägger alla cyklar i en list
                Console.Clear();
                foreach (var bike in bikes) // Skriver ut alla cyklar så att man kan se alla modeller och ID för att kunna mata in vilken cykel som hyrdes
                {
                    Console.WriteLine("Here's the list of avaible bicycles");
                    Console.WriteLine($"Bicycle ID {bike.bicycle_id}, Manufacturer: {bike.bicycle_brandname}");
                }
                Console.WriteLine("Choose by typing in the Bicycle ID for the booking.");
                bikeOrder.bicycle_id = int.Parse(Console.ReadLine());       // cykel ID input

                List<Bookings> orders;
                orders = dbContext.Bookings.ToList();
                foreach (var ord in orders)
                {
                    Console.WriteLine("For the internal booking system, type in the Booking ID just made");
                    Console.WriteLine($"ID : {ord.booking_id}, date: {ord.rent_date} ");
                }

                bikeOrder.booking_id = int.Parse(Console.ReadLine()); // hämtar in och lägger till order id i bikeOrder
                dbContext.Bicycle_bookings.Add(bikeOrder);
                dbContext.SaveChanges();
                Console.WriteLine("The booking is now in the system ");
            }

            BackToMenu();
        }
        //Method to add bicycles into database.
        private static void AddBicycle()
        {
            Console.Clear();
            var bicycle = new Bicycle();
            List<Store> Stores;

            Console.WriteLine("What Manufacturer is the bicycle?");
            bicycle.bicycle_brandname = Console.ReadLine();
            Console.WriteLine("What wheeltype does bicycle have?");
            bicycle.wheeltype = Console.ReadLine();
            Console.WriteLine("What is the weekly rentprice?");
            bicycle.bicycleprice = Console.ReadLine();

            using (var dbContext = new Database())
            {
                Stores = dbContext.Store.ToList();

                foreach (var store in Stores)
                {
                    Console.WriteLine($"{store.StoreID} : {store.StoreLocation} ");

                }
                Console.WriteLine("Enter the store ID the bike belongs to");
                var StoreId = int.Parse(Console.ReadLine());
                bicycle.Store = Stores.Find(x => x.StoreID == StoreId);

                dbContext.Bicycle.Add(bicycle);
                dbContext.SaveChanges();
            }


            Console.WriteLine($"Bicycle ID: {bicycle.bicycle_id} has been added.");

            BackToMenu();
        }

        //Method for updating bicycles 
        private static void EditBicycle()
        {
            Console.Clear();
            var newbook = new Bookings();
            List<Bookings> allOrders;


            using (var dbContext = new Database())
            {
                allOrders = dbContext.Bookings.ToList();
                foreach (var order in allOrders)
                {
                    Console.WriteLine($"Booking ID: {order.booking_id}, , CID: {order.Customer}, Price: {order.price}, ReturnDate: {order.return_date}");
                    Console.WriteLine("");
                }



                Console.WriteLine("Type in the order ID of the order you would like to edit.");
                var idInput = int.Parse(Console.ReadLine());            // Here's where the bookingID is put in 
                Console.WriteLine("What in the order would you like to change?");
                Console.WriteLine("");
                Console.WriteLine("1. Change the price");
                Console.WriteLine("2. Change return date");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":       // Change in totalcost of the order
                        Console.WriteLine("Type in the new subtotal?");
                        newbook = dbContext.Bookings.Where(o => o.booking_id == idInput).First();
                        newbook.price = Console.ReadLine();
                        dbContext.Bookings.Update(newbook);
                        dbContext.SaveChanges();
                        break;
                    case "2":      // Change in the returndate
                        Console.WriteLine("Type in new Return date");
                        newbook = dbContext.Bookings.Where(o => o.booking_id == idInput).First();
                        newbook.return_date = Console.ReadLine();
                        dbContext.Bookings.Update(newbook);
                        dbContext.SaveChanges();
                        break;
                    default:
                        break;
                }

            }

            BackToMenu();

        }

        // a metod to delete specific bicycle
        private static void DeleteBicycle()
        {
            Console.Clear();
            List<Bicycle> bikes;
            var bicycle = new Bicycle();


            using (var dbContext = new Database())

            {
                bikes = dbContext.Bicycle.ToList();

                foreach (var deletebicycle in bikes)
                {
                    Console.WriteLine($"Bicycle ID: {deletebicycle.bicycle_id}, Manufacturer: {deletebicycle.bicycle_brandname}, Wheeltype: {deletebicycle.wheeltype}, Price: {deletebicycle.bicycleprice}");
                }

                Console.WriteLine("Write in the ID of the bike thate you want to remove from the database: ");
                var Input = int.Parse(Console.ReadLine());
                bicycle = dbContext.Bicycle.Where(b => b.bicycle_id == Input).First();
                dbContext.Bicycle.Remove(bicycle);
                dbContext.SaveChanges();

            }
            BackToMenu();
        }

        // a method to show all customers.
        private static void ShowCustomers()
        {
            Console.Clear();
            List<Customer> customerInfo;
            Console.WriteLine("Here's a list of the customer");

            using (var dbContext = new Database())
            {
                customerInfo = dbContext.Customer.ToList();

                foreach (var customer in customerInfo)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"CID: {customer.CID}, Phone: {customer.phone_number}, name: {customer.lastname} {customer.firstname}, email: {customer.email}");
                    Console.WriteLine("");
                }

            }

            BackToMenu();
        }

        //shows all bookings in the system.
        private static void ShowBookings()
        {
            Console.Clear();
            List<Bookings> booking;
            Console.WriteLine("These are all the previous orders made by customers");

            using (var dbContext = new Database())
            {
                booking = dbContext.Bookings.ToList();
                foreach (var order in booking)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Booking ID: {order.booking_id}, Subtotal: {order.price}, CID: {order.Customer}");
                    Console.WriteLine("");
                }
            }

            BackToMenu();
        }

        //a method to list all stores.
        private static void ListStores()
        {
            Console.Clear();
            List<Store> stores;


            using (var dbContext = new Database())
            {
                stores = dbContext.Store.ToList();
                Console.WriteLine("Here's a list of our stores");

                foreach (var store in stores)
                {

                    Console.WriteLine($"Store ID: {store.StoreID}, StoreLocation: {store.StoreLocation}");
                    Console.WriteLine("");
                }

            }

            BackToMenu();
        }
        //Method for deleting a store
        private static void DeleteStore()
        {
            Console.Clear();
            List<Store> stores;
            var shop = new Store();


            using (var dbContext = new Database())

            {
                stores = dbContext.Store.ToList();

                foreach (var store in stores)
                {
                    Console.WriteLine($"Store ID: {store.StoreID}, StoreLocation: {store.StoreLocation}");

                }
                Console.WriteLine("Write in the ID of the store that you want to remove");
                var Input = int.Parse(Console.ReadLine());
                shop = dbContext.Store.Where(b => b.StoreID == Input).First();
                dbContext.Store.Remove(shop);
                dbContext.SaveChanges();


                BackToMenu();
            }
        }
        //Method for deleting a booking

        private static void DeleteBooking()
        {
            Console.Clear();
            List<Bookings> bookings;
            var order = new Bookings();


            using (var dbContext = new Database())

            {
                bookings = dbContext.Bookings.ToList();

                Console.WriteLine("Listed bookings");

                foreach (var book in bookings)
                {
                    Console.WriteLine($"Booking ID: {book.booking_id}");
                }
                Console.WriteLine("Write in the Booking ID that you want to remove");
                var Input = int.Parse(Console.ReadLine());
                order = dbContext.Bookings.Where(b => b.booking_id == Input).First();
                dbContext.Bookings.Remove(order);
                dbContext.SaveChanges();

                BackToMenu();
            }
        }



        // A method for a bundling addition to database where 3 bicycles and a store is added. Suitable for first use when the DB is empty.
        private static void AddBundle()
        {
            var store = new Store();
            var bike = new Bicycle();        
            var bike2 = new Bicycle();       
            var bike3 = new Bicycle();       


            using (var dbContext = new Database())
            {
                store.StoreLocation = "";
                dbContext.Store.Add(store);                    
                dbContext.SaveChanges();

                bike.bicycle_brandname = "Aliexpress turbo";
                bike.wheeltype = "Sport";
                bike.bicycleprice = "650";
                bike.StoreID = store.StoreID;
                dbContext.Bicycle.Add(bike);
                dbContext.SaveChanges();

                bike2.bicycle_brandname = "Lidl ekocykel";
                bike2.wheeltype = "Bränd";
                bike2.bicycleprice = "100";
                bike2.StoreID = store.StoreID;
                dbContext.Bicycle.Add(bike2);
                dbContext.SaveChanges();

                bike3.bicycle_brandname = "Euroshopper PrimeBike";
                bike3.wheeltype = "Budget";
                bike3.bicycleprice = "5";
                bike3.StoreID = store.StoreID;
                dbContext.Bicycle.Add(bike3);
                dbContext.SaveChanges();

            }
            BackToMenu();
        }
    }
}

