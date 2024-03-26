using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesDAL.Models
{
    public class AccountContext : IdentityDbContext
    {
        public AccountContext()
        {
            
        }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            
        }

       
    }
}
