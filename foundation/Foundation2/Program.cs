using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // set up customer and address
        Address address1 = new Address("123 street", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Hannah Dockter", address1);

        Address address2 = new Address("Yuxi street", "YongHe", "TPE", "TW");
        Customer customer2 = new Customer("Sabrina Chang", address2);

        //Set up the order1
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Macbook", "P001", 1500,1));
        order1.AddProduct(new Product("Mouse", "P002", 250, 3));

        //Set up the order2
        Order order2 = new Order(customer1);
        order2.AddProduct(new Product("Chair", "P003", 750,1));
        order2.AddProduct(new Product("Mattress", "P004", 1999, 3));

        //Show order1
        Console.WriteLine(order1.GetPackageLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        //Show order2
        Console.WriteLine(order2.GetPackageLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}