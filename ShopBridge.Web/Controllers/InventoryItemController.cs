using ShopBridge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;

namespace ShopBridge.Web.Controllers
{
    public class InventoryItemController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<InventoryItem> itemList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("InventoryItem").Result;
            itemList = response.Content.ReadAsAsync<List<InventoryItem>>().Result;
            var itemData = new InventoryItemDTO()
            {
                InventoryItemList = itemList.ToList()
            };
            return View(itemData);
        }

        [HttpPost]
        public ActionResult Create(InventoryItemDTO itemDto, HttpPostedFileBase ImageFile)
        {
            if(ImageFile == null)
            {
                itemDto.InvItem.ImagePath = "~/Content/Images/noimage/noimage.jpg";
            }
            else
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                itemDto.InvItem.ImagePath = "~/Content/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                ImageFile.SaveAs(fileName);
            }
            

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("InventoryItem", itemDto.InvItem).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("Create");
        }
        
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("InventoryItem/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Create");
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("InventoryItem/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<InventoryItem>().Result);
        }
    }
}