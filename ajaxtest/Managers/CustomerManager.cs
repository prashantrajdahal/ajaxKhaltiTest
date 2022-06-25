using ajaxtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajaxtest.Managers
{
    public class CustomerManager
    {
        //Retrive Operation
        public  Customer GetCustomer(Guid id)
        {
            using (var context = new DatabaseContext())
            {
                Customer customer = context.Customer.FirstOrDefault(r => r.CustomerId == Id);
                Console.WriteLine(customer.CustomerId);
                Console.Read();
            }
            return null;   
        }


        //Create operation
        public Customer AddCustomer(string cus)
        {
            using (var context = new DatabaseContext())
            {
                Customer customer = new()
                {
                    FirstName="Prashant",
                    MiddleName="Raj",
                    LastName="Dahal",
                    Email="workwithprashantdahal@gmail.com",
                    PhoneNumber="9867898011",
                    TicketAmount=1000
                };
                context.Customer.Add(customer);
                context.SaveChanges();
                Console.WriteLine("Added to database");
            }
            return null;
        }


        //update operation
        public Customer UpdateCustomer(Guid Id, String Cus)
        {
            using (var context = new DatabaseContext())
            {
                Customer customer = context.Customer.FirstOrDefault(r => r.CustomerId == Id);
                customer.FirstName = Cus;
                context.SaveChanges();
            }
            return null;
        }


        //remove operation
        public Customer RemoveCustomer(string FirstName)
        {
            using (var context = new DatabaseContext())
            {
                Customer customer = context.Customer.FirstOrDefault(r => r.CustomerId == Id);
                context.Customer.Remove(customer);
                context.SaveChanges();
            }
            return null;
        }
    }
}
