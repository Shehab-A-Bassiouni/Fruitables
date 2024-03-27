using FruitablesBL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface IproductRepo
    {
        ProductListVM GetProducts(int categID, int sellerID, decimal maxPrice, string pName, int pageNumber);


        public Task<ProductVM> getProdDetais(int productId);


        IEnumerable<ManageProductVM> GetAllProducts();
        public IEnumerable<ManageProductVM> GetAllProducts(int sellerId);
        void CreateProduct(ManageProductVM product);
        ManageProductVM GetProductById(int productId);
        void UpdateProduct(ManageProductVM product);
        void DeleteProduct(int productId);
        public ManageProductVM GetProductForEdit(int productId);

    }
}
