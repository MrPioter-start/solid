using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOLID
{
    internal class OrderLine
    {
        protected Order order;
        protected Customer customer;
        protected List<Item> items;

        public OrderLine(Order order, List<Item> items, Customer customer)
        {
            this.order = order;
            this.items = items;
            this.customer = customer;
        }

        public double Cost(int i, int quantity, List<Item> a)
        {
            return a[i].GetUnitPrice() * quantity;
        }



        public string TotalCost()
        {
            double totalcost = 0;
            List<Item> items_buy = Addition();
            int p;
            Console.Clear();
            Console.WriteLine("Ваши товары: ");
            for (int i = 0; i < items_buy.Count; i++)
            {
                Console.Write($"{items_buy[i].GetName()} {items_buy[i].GetUnitPrice()}, введите количество: ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                totalcost += Cost(i, quantity, items_buy);
            }
            double totalcostproc = totalcost;
            double procent1=0;
            if (order.GetExpressDelivery() == true)
            {
                procent1 = totalcostproc * 0.25;
                totalcostproc += procent1;
            }
            if (order.GetExpressDelivery() && totalcostproc<20 && customer.GetPrivileged() == false)
            {
                return $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\nИтого: {totalcost}\n" +
                    $"Ваша надбавка за срочность 25%: {procent1}\n" +
                $"Итого за срочность: {totalcostproc}" +
                $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n";
            }
            if (customer.GetPrivileged() == true && totalcost > 20.0 && order.GetExpressDelivery())
            {
                double procent = totalcostproc * 0.15;
                totalcostproc -= procent;
                return $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\nИтого: {totalcost}\n" +
                    $"Ваша надбавка за срочность 25%: {procent1}\n" +
                    $"Ваша скидка за привелегии 15%: {procent}\n" +
                $"Итого за срочность: {totalcostproc}" +
                $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n";
            }
            if (customer.GetPrivileged() == true && totalcost > 20.0 && order.GetExpressDelivery()==false)
            {
                double procent = totalcostproc * 0.15;
                totalcostproc -= procent;
                return $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\nИтого: {totalcost}\n" +
                    $"Ваша скидка за привелегии 15%: {procent}\n" +
                $"Итого за срочность: {totalcostproc}" +
                $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n";
            }
            Thread.Sleep(2000);
            return $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\nИтого: {totalcost}" +
                $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n";
        }

        public List<Item> Addition()
        {
            int p;
            List<Item> items_buy = new List<Item>();
            do
            {
                Console.Clear();
                Console.WriteLine("Ваши товары: ");
                for (int i = 0; i < items_buy.Count; i++)
                {
                    Console.WriteLine($"{i}: {items_buy[i].GetName()}");
                }
                Console.WriteLine("\n----------------------------------------------\n");
                Console.WriteLine("Все товары: ");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i}: {items[i].GetName()}");
                }
                Console.Write("Добавить (-1 - если нет): ");
                int j = Convert.ToInt32(Console.ReadLine());
                if (j != -1 && j <= items.Count)
                {
                    items_buy.Add(items[j]);
                    items.Remove(items[j]);
                }
                Console.Write("Удалить (-1 - если нет): ");
                int d = Convert.ToInt32(Console.ReadLine());
                if (d != -1 && j <= items_buy.Count) items_buy.Remove(items_buy[d]);
                Console.Write("Продолжить (1-да; 0-нет): ");
                p = Convert.ToInt32(Console.ReadLine());
            } while (p != 0);
            return items_buy;
        }

        public override string ToString()
        {
            return order.ToString() + this.TotalCost();
        }
        //$"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n"
    }
}
