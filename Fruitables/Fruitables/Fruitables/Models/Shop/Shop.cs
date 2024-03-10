using BL_ShopManager = FruitablesBL.EntityManagement.ShopManager.ShopManage;
namespace Fruitables.Models.Shop
{
    public class Shop
    {
        public Shop() {
            BL_ShopManager.LoadSellers();
        }

        public List<string> GetShopsNames() {
            return BL_ShopManager.GetShopNames();
        }
    }
}
