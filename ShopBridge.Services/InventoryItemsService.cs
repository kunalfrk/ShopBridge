using ShopBridge.Database;
using ShopBridge.Entities;
using System.Linq;

namespace ShopBridge.Services
{
    public class InventoryItemsService : IInventoryItem
    {
        public IQueryable<InventoryItem> GetInventoryItems()
        {
            using (var context = new SBContext())
            {
                var items = context.InventoryItems.ToList();
                return items.AsQueryable();
            }
        }

        public InventoryItem GetInventoryItem(int ID)
        {
            using (var context = new SBContext())
            {
                return context.InventoryItems.Find(ID);
            }
        }

        public void SaveInventoryItem(InventoryItem inventoryItem)
        {
            using (var context = new SBContext())
            {
                context.InventoryItems.Add(inventoryItem);
                context.SaveChanges();
            }
        }
        public InventoryItem DeleteInventoryItem(int ID)
        {
            using (var context = new SBContext())
            {
                var item = context.InventoryItems.Find(ID);
                context.InventoryItems.Remove(item);
                context.SaveChanges();

                return item;
            }
        }
    }
}