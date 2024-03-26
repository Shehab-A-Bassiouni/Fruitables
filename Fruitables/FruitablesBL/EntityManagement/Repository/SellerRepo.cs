using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class SellerRepo : ISellerRepo
    {
        private readonly FRUITABLESContext DbContext;
        public SellerRepo(FRUITABLESContext _db)
        {
            DbContext = _db;

        }

        public List<SellerVM> getALlshops()
        {

            List<SellerVM> Allseleers = new List<SellerVM>();

            foreach (var Sel in DbContext.Sellers.Include(s=>s.SellerNavigation))
            {
                var user = DbContext.Users.FirstOrDefault(x => x.UserId == Sel.SellerId);
                Allseleers.Add(new SellerVM()
                {
                    Address = Sel.Address,
                    CommercialName = Sel.CommercialName,
                    Logo = Sel.Logo,
                    Rate = Sel.Rate,
                    SellerId = Sel.SellerId
                });
               
            }
            return Allseleers;

        }


        public SellerListVM getALlshops(int pageNumber)
        {
            try
            {
                int itemsPerPage = 6;
                int skipped = (pageNumber - 1) * itemsPerPage;
                SellerListVM SelerList = new SellerListVM();
                SelerList.Count = DbContext.Sellers.ToList().Count;
                foreach (var Sel in DbContext.Sellers.Include(s=> s.SellerNavigation).Skip(skipped).Take(6))
                {
                    SelerList.selerVMS.Add(new SellerVM()
                    {
                        Address = Sel.Address,
                        CommercialName = Sel.CommercialName,
                        Logo = Sel.Logo,

                        Rate = Sel.Rate,
                        SellerId = Sel.SellerId
                    });
                }
                return SelerList;


            }
            catch (Exception ex)
            {

                return new SellerListVM();
            }


        }

        SellerListVM ISellerRepo.getShopsbyName(string sName, int pageNumber)
        {
            try
            {

                int itemsPerPage = 2;
                int skipped = (pageNumber - 1) * itemsPerPage;
                SellerListVM SelerList = new SellerListVM();

                var AllSellers = DbContext.Sellers.Where(s => s.CommercialName.Contains(sName)).ToList();
                SelerList.Count = AllSellers.Count;

                foreach (var Sel in AllSellers.Skip(skipped).Take(6))
                {
                    SelerList.selerVMS.Add(new SellerVM()
                    {
                        Address = Sel.Address,
                        CommercialName = Sel.CommercialName,
                        Logo = Sel.Logo,
                        Rate = Sel.Rate,
                        SellerId = Sel.SellerId
                    });
                }
                return SelerList;


            }
            catch (Exception ex)
            {

                return new SellerListVM();
            }


        }

        public SellerVM GetSellerById(int sellerId)
        {
            var seller = DbContext.Sellers.FirstOrDefault(s => s.SellerId == sellerId);
            return SellerVMMapper.MapToSellerVM(seller);
        }
        public List<SellerVM> GetAllSellers()
        {
            var sellers = DbContext.Sellers.ToList();
            return sellers.Select(seller => SellerVMMapper.MapToSellerVM(seller)).ToList();
        }

    }
}
