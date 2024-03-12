using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class SellerRepo: ISellerRepo
    {
        private readonly FRUITABLESContext DbContext;
        public SellerRepo(FRUITABLESContext _db)
        {
            DbContext = _db;
            
        }

        public List<SellerVM> getALlshops()
        {
            
                List<SellerVM> Allseleers = new List<SellerVM>();

                foreach (var Sel in DbContext.Sellers.Take(20))
                {
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

        public List<SellerVM> getALlshops(int pageNumber)
        {
            int itemsPerPage = 2;
            int skipped = (pageNumber - 1) * itemsPerPage;
            List<SellerVM> Allseleers = new List<SellerVM>();

            foreach (var Sel in DbContext.Sellers.Skip(skipped).Take(20))
            {
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
    }
}
