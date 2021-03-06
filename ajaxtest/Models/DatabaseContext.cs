using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajaxtest.Models
{
    public class DatabaseContext: DbContext
    {
        
        public DatabaseContext()
        {
            
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public object Customer { get;  set; }
    }
}
