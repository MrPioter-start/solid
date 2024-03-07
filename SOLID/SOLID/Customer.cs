using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class Customer
    {
        public static int Code;

        protected string full_name;
        protected string contact_phone;
        protected bool privileged;

        public Customer(int code, string full_name, string contact_phone, bool privileged)
        {
            this.full_name = full_name;
            this.contact_phone = contact_phone;
            this.privileged = privileged;
            Code++;
        }

        public Customer() { }

        public bool GetPrivileged() {  return privileged; }

        public Customer SetNewCustomer()
        {
            Console.Write("Введите ФИО: ");
            full_name = Console.ReadLine();
            Console.Write("Введите номер: ");
            contact_phone = Console.ReadLine();
            int a=2;
            while (a != 0 && a != 1)
            {
                Console.Write("Вы привелигированный клиент (1-да; 0-нет): ");
                a = Convert.ToInt32(Console.ReadLine());
            }
            if (a == 0) privileged = false;
            else privileged = true;
            return new Customer(GetCode(),full_name,contact_phone,privileged);
        }

        public int GetCode()
        {
            return Code;
        }

        public override string ToString()
        {
            return $"\n---------------------------------------------\n" +
                $"Code: {Code}\nFullName: {full_name}\nPhone: {contact_phone}\nPrivileged: {privileged}" +
                $"\n---------------------------------------------\n";
        }
    }
}
