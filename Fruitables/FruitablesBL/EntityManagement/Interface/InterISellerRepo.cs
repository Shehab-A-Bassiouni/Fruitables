using FruitablesBL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface ISellerRepo
    {
        List<SellerVM> getALlshops();
        SellerListVM getALlshops(int pageNumber);
        SellerListVM getShopsbyName(string sName, int pageNumber);

        public SellerVM GetSellerById(int sellerId);
        public List<SellerVM> GetAllSellers();

    }
}
