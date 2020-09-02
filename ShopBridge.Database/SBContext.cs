using ShopBridge.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Database
{
    public class SBContext : DbContext
    {
        public SBContext() : base("ShopBridgeConnection")
        {

        }
        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}
