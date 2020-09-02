using ShopBridge.Entities;
using System.Linq;

namespace ShopBridge.Services
{
    public interface IInventoryItem
    {
        IQueryable<InventoryItem> GetInventoryItems();
        InventoryItem GetInventoryItem(int ID);
        void SaveInventoryItem(InventoryItem inventoryItem);        
        InventoryItem DeleteInventoryItem(int ID);
    }
}