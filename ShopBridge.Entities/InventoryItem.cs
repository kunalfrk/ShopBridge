using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.Entities
{
    public class InventoryItem
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }        
        public string Description { get; set; }        
        public decimal Price { get; set; }
        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
