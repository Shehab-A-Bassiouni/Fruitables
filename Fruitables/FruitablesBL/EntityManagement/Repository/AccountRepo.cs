using FruitablesBL.EntityManagement.Interface;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FruitablesBL.EntityManagement.Repository
{
    public class AccountRepo : IAccountRepo
    {
        public FRUITABLESContext Context { get; set; }

        public AccountContext AccContext { get; set; }

        public AccountRepo(FRUITABLESContext _Context, AccountContext accContext)
        {
            Context = _Context;
            AccContext = accContext;
        }

        bool IAccountRepo.AddInUsers(User newuser)
        {
            if (newuser != null)
            {
                Context.Users.Add(newuser);
                Context.SaveChanges();
                return true;
            }

            return false;
        }

        bool IAccountRepo.AddinCustomers(Customer newcustomer)
        {
            if (newcustomer != null)
            {
                Context.Customers.Add(newcustomer);
                Context.SaveChanges();
                return true;
            }

            return false;
        }
        bool IAccountRepo.AddinSellers(Seller newseller)
        {
            if (newseller != null)
            {
                Context.Sellers.Add(newseller);
                Context.SaveChanges();
                return true;
            }

            return false;
        }

        bool IAccountRepo.AddinAdmins(Admin newadmin)
        {
            if (newadmin != null)
            {
                Context.Admins.Add(newadmin);
                Context.SaveChanges();
                return true;
            }

            return false;
        }

       
    }
}
