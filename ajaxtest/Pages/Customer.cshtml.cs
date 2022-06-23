using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ajaxtest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ajaxtest.Pages
{
    public class CustomerModel : PageModel
    {

        DatabaseContext _Context;
        public CustomerModel(DatabaseContext databaseContext)
        {
            _Context = databaseContext;
        }


        [BindProperty]
        public Customer Customer { get; set; }
        public void OnGet()
        {
        }

        //Create Customer Table
        public ActionResult OnPostUpdate()
        {
            var customer = Customer;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var result = _Context.Add(customer);
            _Context.SaveChanges(); // Saving Data in database
            return RedirectToPage('/');
        }

        //Delete Customer Table
        public ActionResult OnGetDelete(Guid CustomerId)
        {
            if (CustomerId != null)
            {
                var data = (from Customer in _Context.Customers
                            where Customer.CustomerId == CustomerId
                            select Customer).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("/");
        }

        //Update Customer Table
        //Since I have to create seperate page for creating two post with simailar attribute i havefixed problem
        public ActionResult Update()
        {
            var customer = Customer;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _Context.Entry(customer).Property(x => x.FirstName ).IsModified = true;
            _Context.SaveChanges();
            return RedirectToPage("/");
        }
    }
}
