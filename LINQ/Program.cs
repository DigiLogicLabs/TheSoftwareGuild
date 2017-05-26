using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;


namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
           //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
           // Exercise15();
            //Exercise16();
            //Exercise17();
              //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
           // Exercise22();
            //Exercise23();
             // Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
           //Exercise28();
            //Exercise29();
            //Exercise29();
            //Exercise30();
            Exercise31();


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product  in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.Where(p => p.UnitsInStock == 0);
            PrintProductInformation(filtered);

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {

            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Where(x => x.UnitPrice > 3M && x.UnitsInStock > 0);
            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customersinfo = DataLoader.LoadCustomers();
     

           var filtered =
                from c in customersinfo
                where c.Region == "WA"
                select c;

            PrintCustomerInformation(filtered);

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> theProducts = DataLoader.LoadProducts();

            var printIt =
                from products in theProducts
                select new {products.ProductName};
            foreach (var prod in printIt)
            {
                Console.WriteLine(prod.ProductName);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> theProducts = DataLoader.LoadProducts();

            var printing =
                from prod in theProducts 
                select new {prod.ProductName, prod.Category, unitprice = prod.UnitPrice*1.25M, prod.ProductID, prod.UnitsInStock};
            
            foreach (var info in printing)
            {
                
                Console.WriteLine(info);
            }



        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> theProducts = DataLoader.LoadProducts();

            var printing =
                from prod in theProducts
                select new {ProdName = prod.ProductName.ToUpper(), ProdCategory = prod.Category.ToUpper()};
            foreach (var information in printing)
            {
                Console.WriteLine(information);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> theProducts = DataLoader.LoadProducts();
            bool reorder = true;

            var printing =
                from prod in theProducts
                select new {prod.ProductName, prod.Category, prod.ProductID, prod.UnitPrice, Reorder = prod.UnitsInStock < 3, prod.UnitsInStock };

            foreach (var information in printing)
            {
               
                Console.WriteLine(information);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> theProducts = DataLoader.LoadProducts();
            var printing =
                from prod in theProducts
                select new {prod.ProductName, prod.Category, prod.ProductID, prod.UnitPrice, prod.UnitsInStock, StockValue = prod.UnitPrice * prod.UnitsInStock};

            foreach (var information in printing)
            {
                Console.WriteLine(information);
            }

        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {

            var numbers = DataLoader.NumbersA.Where(o => o % 2 == 0);
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }

            
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customersinfo = DataLoader.LoadCustomers();

            var printing =
                from customer in customersinfo

                where customer.Orders.Any(o => o.Total < 500)
                select customer;

            PrintCustomerInformation(printing);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var numbers = DataLoader.NumbersC.Where(o => o % 2 == 1).Take(3);
            foreach (var numb in numbers)
            {
                Console.WriteLine(numb);
            }
            
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var numbers = DataLoader.NumbersB.Skip(3);
            foreach (var nums in numbers)
            {
                Console.WriteLine(nums);
            }
            
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> customersinfo = DataLoader.LoadCustomers();
            var customers = customersinfo.Where(c => c.Region == "WA").Select(cust =>
                new {p = cust.CompanyName, d = cust.Orders.OrderByDescending(o => o.OrderDate).First()});

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.p + "|||---|||" + customer.d.OrderDate);

            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbers = DataLoader.NumbersC.Where(o => o < 6);
            foreach (var numb in numbers)
            {
                Console.WriteLine(numb);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var numbers = DataLoader.NumbersC.SkipWhile(o => o % 3 != 0);
            foreach (var nums in numbers)
            {
                Console.WriteLine(nums);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> product = DataLoader.LoadProducts();

            var products =
                from abc in product
                orderby abc.ProductName
                select abc;

            PrintProductInformation(products);

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> production = DataLoader.LoadProducts();

            var productanswer =
               
                from pro in production
                orderby pro.UnitsInStock
                select pro;

            PrintProductInformation(productanswer);

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> product = DataLoader.LoadProducts();

            var sortedproducts =
                from p in product
                orderby p.Category, p.UnitPrice descending
                select p;

            PrintProductInformation(sortedproducts);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var numbers = DataLoader.NumbersB.Reverse();
            foreach (var numberRev in numbers)
            {
                Console.WriteLine(numberRev);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name 
        /// //and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var productOrder =
                from prod in products
                group prod by prod.Category
                into g
                select new {c = g.Key, p = g};

            PrintProductInformation(products);

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var orderbyDate = customers.Select(c => new
            {
                CustomerName = c.CompanyName,

                Orders = c.Orders.GroupBy(o => new
                {
                    Year = o.OrderDate.Year,

                    Month = o.OrderDate.Month
                }).Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Number = g.Count(),
                    Total = g.Sum(h => h.Total)
                })
                
            });

            foreach (var customer in orderbyDate)
            {
                Console.WriteLine(customer.CustomerName);
                foreach (var totalOut in customer.Orders)
                {
                    Console.WriteLine(totalOut);
                }
            }

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();

            var unique = 
                products.Select(p => p.Category).Distinct();

            foreach (var item in unique)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();

            var makesure =
                from product in products
                where product.ProductID == 789
                select product;

            PrintProductInformation(makesure);
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();

            var ifoutofstock =
                products.Where(p => p.UnitsInStock == 0).Select(c => c.Category).Distinct();

            foreach (var value in ifoutofstock)
            {
                Console.WriteLine(value);
            }

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            var noOutofStock =
                products.GroupBy(p => p.Category).Where(c => c.All
                    (d => d.UnitsInStock != 0)).Select(g => g.Key);
            foreach (var item in noOutofStock)
            {
                Console.WriteLine( $"{item} has no products out of stock");
            }



        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var numbers = DataLoader.NumbersA.OrderBy(o => o % 2 == 1).Count(o => o % 2 == 1);
            Console.WriteLine(numbers);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var customID = customers.Select(a => new
            {
                customersID = a.CustomerID,
                count = a.Orders.Count()
            });

            foreach (var item in customID)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();

            var distinct =
                from prod in products
                group prod by prod.Category
                into g
                select new
                {
                    category = g.Key,
                    productNumbers = g.Count()
                };
            foreach (var person in distinct)
            {
                Console.WriteLine(person);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> products = DataLoader.LoadProducts();

            var distinct =
                from product in products
                group product by product.Category
                into g
                select new
                {
                    category = g.Key,
                    totalunits = g.Sum(c => c.UnitsInStock)
                };
            foreach (var people in distinct)
            {
                Console.WriteLine(people);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();

            var list =

                from product in products
                group product by product.Category
                into g
                select new
                {
                    Category = g.Key,
                    Lowest = g.OrderBy(c => c.UnitPrice).First()
                };
            foreach (var person in list)
            {
                Console.WriteLine($"{person.Category}, {person.Lowest.ProductName}");
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();

            var list =
            (from product in products
                group product by product.Category
                into g
                select new
                {
                    Category = g.Key,
                    Average = g.Average(p => p.UnitPrice)
                }).OrderByDescending(p => p.Average).Take(3);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
