using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RequestSupportApp.Models;

namespace RequestSupportApp.Data
{
    public class RequestSupportAppContext : DbContext
    {
        public RequestSupportAppContext (DbContextOptions<RequestSupportAppContext> options)
            : base(options)
        {
        }

        public DbSet<RequestSupportApp.Models.Ticket> Ticket { get; set; }

        public DbSet<RequestSupportApp.Models.Employee> Employee { get; set; }
    }
}
