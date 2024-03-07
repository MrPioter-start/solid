using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class Order
    {
        protected DateTime creation_date;
        protected string address;
        protected bool express_delivery;
        protected Customer customer;

        public bool GetExpressDelivery() { return express_delivery; }

        public Order(DateTime creation_date, string address, bool express_delivery, Customer customer)
        {
            this.creation_date = creation_date;
            this.address = address;
            this.express_delivery = express_delivery;
            this.customer = customer;
        }

        public override string ToString()
        {
            return $"Order:\n---------------------------------------------\n---------------------------------------------\n" +
                $"Number {customer.GetCode()}\nCreation Date: {creation_date.ToShortDateString()}\n" +
                $"Address: {address}\nExpress_delivery: {express_delivery}\n---------------------------------------------\n" +
                $"Customer: {customer}---------------------------------------------\n";
        }
    }
}
