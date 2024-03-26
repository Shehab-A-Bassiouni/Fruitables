using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface IAccountRepo
    {
        bool AddInUsers(User newuser);

        bool AddinCustomers(Customer newcustomer);

        bool AddinSellers(Seller newseller);


        bool AddinAdmins(Admin newadmin);


    }
}
