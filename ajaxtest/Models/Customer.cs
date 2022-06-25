using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ajaxtest.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }= Guid.NewGuid();
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean IsMerchant { get; set; } = false;
        public string Password { get; set; }
        public Boolean ISRedeemed { get; set; } = false;
        public int TicketAmount { get; set; }

        public static implicit operator Customer(string v)
        {
            throw new NotImplementedException();
        }
    }
}
