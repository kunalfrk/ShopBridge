using ShopBridge.Entities;
using ShopBridge.Services;
using ShopBridge.WebAPI.Models;
using ShopBridge.WebAPI.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;

namespace ShopBridge.WebAPI.Controllers
{
    public class InventoryItemController : ApiController
    {
        private readonly IInventoryItem _itemService = null;
        public InventoryItemController(IInventoryItem itemService)
        {
            this._itemService = itemService;
        }

        //GET: api/InventoryItem
        [HttpGet]
        public IQueryable<ApiInventoryItem> GetInventoryItems()
        {
            EntityMapper<InventoryItem, ApiInventoryItem> mapObj = new EntityMapper<InventoryItem, ApiInventoryItem>();
            var items = _itemService.GetInventoryItems();

            List<InventoryItem> itemList = items.ToList();
            List<ApiInventoryItem> inventoryItems = new List<ApiInventoryItem>();
            foreach (var item in itemList)
            {
                inventoryItems.Add(mapObj.Translate(item));
            }
            return inventoryItems.AsQueryable();
        }

        //GET: api/InventoryItem/1
        [HttpGet]
        [ResponseType(typeof(ApiInventoryItem))]
        public IHttpActionResult GetInventoryItem(int id)
        {
            EntityMapper<InventoryItem, ApiInventoryItem> mapObj = new EntityMapper<InventoryItem, ApiInventoryItem>();
            InventoryItem dalItem = _itemService.GetInventoryItem(id);
            ApiInventoryItem inventoryItem = new ApiInventoryItem();
            inventoryItem = mapObj.Translate(dalItem);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return Ok(inventoryItem);
        }

        //POST: api/InventoryItem
        [HttpPost]
        [ResponseType(typeof(ApiInventoryItem))]
        public IHttpActionResult PostInventoryItem([FromBody]ApiInventoryItem inventoryItem)
        {
            try
            {
                if (inventoryItem != null && ModelState.IsValid)
                {
                    EntityMapper<ApiInventoryItem, InventoryItem> mapObj = new EntityMapper<ApiInventoryItem, InventoryItem>();
                    InventoryItem itemObj = new InventoryItem();
                    itemObj = mapObj.Translate(inventoryItem);
                    _itemService.SaveInventoryItem(itemObj);
                    return CreatedAtRoute("DefaultApi", new { id = inventoryItem.ID }, inventoryItem);
                }
                else
                {
                    var message = inventoryItem == null ? "Invalid Request" : (string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)) + string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.Exception)));
                    //return BadRequest(message);
                    return Content(HttpStatusCode.BadRequest, message);
                }
            }
            catch (System.Exception)
            {
                return InternalServerError();
            }

        }

        //DELETE: api/InventoryItem/1
        [HttpDelete]
        [ResponseType(typeof(ApiInventoryItem))]
        public IHttpActionResult DeleteInventoryItem(int id)
        {
            EntityMapper<InventoryItem, ApiInventoryItem> mapObj = new EntityMapper<InventoryItem, ApiInventoryItem>();
            InventoryItem dalItem = _itemService.DeleteInventoryItem(id);
            ApiInventoryItem inventoryItem = new ApiInventoryItem();
            inventoryItem = mapObj.Translate(dalItem);

            return Ok(inventoryItem);
        }
    }
}