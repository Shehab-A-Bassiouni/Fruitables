using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class CartRepo //: ICartRepo
    {
     

        private readonly FRUITABLESContext DbContext;
        public CartRepo(FRUITABLESContext _db)
        {
            DbContext = _db;

        }

        public CartRepo()
        {

        }

        public CartVM ToCartVM(List<string> itemData)
        {
            CartVMMapper cartVMMapper = new(itemData);

            return cartVMMapper.ToCartVM();
        }

        public string ToString(CartVM cartVM)
        {
            return JsonConvert.SerializeObject(cartVM);
        }

        public string ToString(List<CartVM> cartVM)
        {
            return JsonConvert.SerializeObject(cartVM);
        }
    }
}
