using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>() { new Item("1", "Молоко", 2.56),
            new Item("2", "Печенье", 2.44), new Item("3", "Вафли", 2.85),
            new Item("4", "Йогурт", 1.78), new Item("5", "Чипсы", 4.78),
            new Item("6", "Сухарики", 1.99), new Item("7", "Сушеная рыба", 2.50),
            new Item("8", "Сок", 4.99), new Item("9", "Сушки", 2.44),
            new Item("10", "Корм", 6.55)};
            Customer customer = new Customer();
            customer.SetNewCustomer();
            Console.WriteLine(customer);
            Order order1 = new Order(new DateTime(2024,03,06),"Асаналиева 22/3/25",true, customer);
            Console.WriteLine(order1);
            Console.WriteLine();
            OrderLine ol = new OrderLine( order1, items, customer);
            Thread.Sleep(2000);
            Console.WriteLine(ol);

        }
    }
}
