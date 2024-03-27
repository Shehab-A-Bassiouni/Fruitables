
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitablesBL.ViewModels;

namespace FruitlessBL.Mapping
{
    public class ManageSellerVMMapper
    {
        public static ManageSellerVM MapToSellerVM(Seller seller)
        {
            if (seller == null)
                return null;

            return new ManageSellerVM
            {
                
                Id = seller.SellerId,
                SellerName =seller.SellerNavigation.FirstName,
                CommercialName = seller.CommercialName,
                Rate = seller.Rate,
                Address = seller.Address,
                Logo = seller.Logo,
                Products = seller.Products.Select(product => new Product
                {
                    Image = product.Image,
                    ProductId = product.ProductId,
                    Description = product.Description,
                    Rate = product.Rate,
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    FeedBacks = product.FeedBacks,
                    
                    Offers = product.Offers
                }).ToList()
            };
        }
        }
    }

