using FruitablesBL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface IOfferRepo
    {
        public Task<List<OffersVM>> GetAllOffrs(int sllerID);
        public Task<OffersVM> GetOffer(int? offerID);
        public Task<OffersVM> CeateOffer(OffersVM offerVM, int sellerID);
        public Task<bool> Delete(int offerID);
        public Task<OffersVM> Edit(OffersVM offerVm);
    }
}
