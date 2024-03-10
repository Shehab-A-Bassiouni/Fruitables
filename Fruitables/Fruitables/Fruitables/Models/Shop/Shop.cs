using BL_ShopManager = FruitablesBL.EntityManagement.ShopManager.ShopManage;
namespace Fruitables.Models.Shop
{
    public class Shop
    {
        public Shop() {
            BL_ShopManager.LoadSellers();
            BL_ShopManager.LoadProducts();

        }

        public List<List<string>>? GetShopsNames() {
            return BL_ShopManager.GetShopNames();
        }
    }
}
