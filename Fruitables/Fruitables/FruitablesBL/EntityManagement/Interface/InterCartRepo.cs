using FruitablesBL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface ICartRepo
    {
        public CartVM? GetItemByID(int _itemID);
    }
}
