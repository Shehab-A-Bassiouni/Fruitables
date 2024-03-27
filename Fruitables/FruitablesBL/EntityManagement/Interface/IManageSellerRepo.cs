using FruitablesBL.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitlessBL.EntityManagement.Interface
{
    public interface IManageSellerRepo
    {
        List<ManageSellerVM> GetALlSeller();
        public ManageSellerVM GetSellerById(int SellerId);

        public ManageSellerVM CreateSeller(ManageSellerVM NewSeller);

        public ManageSellerVM DeleteSeller(int SellerId);

        public ManageSellerVM UpdateSeller(ManageSellerVM NewSeller);

    }
}
