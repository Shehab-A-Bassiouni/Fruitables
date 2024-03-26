using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class OfferRepo : IOfferRepo
    {
        private readonly FRUITABLESContext _context;
        private readonly OfferMapper  _offerMapper;
        public OfferRepo(FRUITABLESContext ctx, OfferMapper offerMappaer) {
        
            _context = ctx;
            _offerMapper = offerMappaer;
        }
        public async Task<OffersVM> CeateOffer(OffersVM offerVM, int sellerID)
        {
            try
            {
                Offer offer = _offerMapper.MapToOffer(offerVM);
                offer.SellerId = sellerID;
                offer.IsActive = true;
                offer.Products = _context.Products.Where(p=> p.SellerId == sellerID).ToList();
                await _context.Offers.AddAsync(offer);
                _context.SaveChanges();
                return offerVM;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return  offerVM;
            }
        }

        public async Task<bool> Delete(int offerID)
        {
            Offer offer = await _context.Offers.FindAsync(offerID);
            if (offer != null) {
                 offer.IsActive = false;
                _context.SaveChanges();

            }
            return true;

        }

        public async Task<OffersVM> Edit(OffersVM offerVm)
        {
            Offer offer = await _context.Offers.FirstOrDefaultAsync(o => o.OfferId == offerVm.OfferId);
            if (offer != null)
            {
                offer.ExpireDate = offerVm.ExpireDate;
                offer.Description = offerVm.Description;
                offer.Discount = offerVm.Discount;  
                _context.SaveChanges();
                return offerVm;
            };
            return offerVm;

        }

        public async Task<List<OffersVM>> GetAllOffrs(int sllerID)
        {
            List<OffersVM> offersVmList = new();
            try
            {
               
                var offers = await _context.Offers.Where(o=> o.SellerId == sllerID).ToListAsync();
                foreach (var item in offers)
                {
                    offersVmList.Add(_offerMapper.MapToOfferVM(item));


                }
                return offersVmList;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return offersVmList;
            }
           

        }

        public async Task<OffersVM> GetOffer(int? offerID)
        {
            try
            {
                Offer offer = await _context.Offers.FirstOrDefaultAsync(o => o.OfferId == offerID);
                if (offer != null)
                {
                    return _offerMapper.MapToOfferVM(offer);
                }
                return new OffersVM();
            }
            
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return new OffersVM();

            }

        }
    }
}
