using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class SellerVMMapper
    {
        public static SellerVM MapToSellerVM(Seller seller)
        {
            if (seller == null)
                return null;

            return new SellerVM
            {
                SellerId = seller.SellerId,
                CommercialName = seller.CommercialName,
                Rate = seller.Rate,
                Address = seller.Address,
                Logo = seller.Logo
            };
        }
    }
}
