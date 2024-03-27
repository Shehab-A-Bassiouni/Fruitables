using FruitlessBL.EntityManagement.Interface;
using FruitlessBL.Mapping;

using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitablesBL.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FruitlessBL.EntityManagement.Repository
{
    public class ManageSellerRepo : IManageSellerRepo
    {
        public readonly FRUITABLESContext DbContext;
        public ManageSellerRepo(FRUITABLESContext _db)
        {
            DbContext = _db;

        }

        public List<ManageSellerVM> GetALlSeller()
        {

            var sellers = DbContext.Sellers
                                   .Include(s => s.SellerNavigation)
                                   .ToList();


            var sellerVMs = sellers.Select(s => ManageSellerVMMapper.MapToSellerVM(s)).ToList();


            return sellerVMs;
        }


        public ManageSellerVM GetSellerById(int sellerId)
        {

            var seller = DbContext.Sellers
                                  .Include(s => s.SellerNavigation).Include(s => s.Products).ToList()
                                  .FirstOrDefault(s => s.SellerId == sellerId);


            return ManageSellerVMMapper.MapToSellerVM(seller);
        }


        public ManageSellerVM UpdateSeller(ManageSellerVM updatedSeller)
        {

            var seller = DbContext.Sellers.FirstOrDefault(s => s.SellerId == updatedSeller.Id);

            if (seller != null)
            {
                seller.SellerNavigation.FirstName=updatedSeller.SellerName;
                seller.Rate = updatedSeller.Rate;
                seller.CommercialName = updatedSeller.CommercialName;

                seller.Address = updatedSeller.Address;
                seller.Logo = updatedSeller.Logo;


                DbContext.SaveChanges();
            }
            return ManageSellerVMMapper.MapToSellerVM(seller);
        }

        public ManageSellerVM CreateSeller(ManageSellerVM newSeller)
        {


            var seller = new Seller
            {
                SellerNavigation = new User
                { 
                    UserId = 4,
                    FirstName = newSeller.SellerName 
                },
                Rate = newSeller.Rate,
                CommercialName = newSeller.CommercialName,
                Address = newSeller.Address,
                Logo = newSeller.Logo
            };

            DbContext.Sellers.Add(seller);
            DbContext.SaveChanges();

            return ManageSellerVMMapper.MapToSellerVM(seller);
        }



        public ManageSellerVM DeleteSeller(int sellerId)
        {

            var seller = DbContext.Sellers.FirstOrDefault(s => s.SellerId == sellerId);

            if (seller != null)
            {

                DbContext.Sellers.Remove(seller);


                DbContext.SaveChanges();
            }


            return ManageSellerVMMapper.MapToSellerVM(seller);
        }

    }
}
