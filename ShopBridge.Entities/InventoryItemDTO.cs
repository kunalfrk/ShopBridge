using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Entities
{
    public class InventoryItemDTO
    {
        public InventoryItem InvItem { get; set; }
        public List<InventoryItem> InventoryItemList { get; set; }
    }
}
