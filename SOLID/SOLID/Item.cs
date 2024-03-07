using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class Item
    {

        protected string article;
        protected string name;
        protected double unit_price;

        

        public Item(string article, string name, double unit_price)
        {
            this.article = article;
            this.name = name;
            this.unit_price = unit_price;
        }

        public Item() { }

        public override string ToString()
        {
            return $"Artivle: {article}\t|\tName: {name}\t|\tUnitPrice: {unit_price}";
        }

        public double GetUnitPrice() { return unit_price; }
        public string GetName() { return name; }
    }
}
