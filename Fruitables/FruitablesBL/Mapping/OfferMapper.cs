using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class OfferMapper
    {
        public  Offer MapToOffer(OffersVM offerVm)
        {
            
            return new Offer
            {
               Description = offerVm.Description,
               OfferId = offerVm.OfferId,
               Discount = offerVm.Discount,
               ExpireDate = offerVm.ExpireDate,
               


            };
        }

        public  OffersVM MapToOfferVM(Offer offer)
        {
            return new OffersVM
            {
                Description = offer.Description,
                OfferId = offer.OfferId,
                Discount = offer.Discount,
                ExpireDate = offer.ExpireDate,


            };
        }
    }
}
