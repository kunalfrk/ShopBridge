using System;
using System.Text;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using ShopBridge.Services;
using ShopBridge.Entities;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using ShopBridge.WebAPI.Controllers;
using ShopBridge.WebAPI.Models;
using System.Net;
using Newtonsoft.Json;
using System.Web.Http.Results;
using Castle.Components.DictionaryAdapter.Xml;
using System.Web.Http.Routing;

namespace ShopBridge.UnitTests
{
    /// <summary>
    /// Summary description for InventoryItemControllerUnitTest
    /// </summary>
    [TestFixture]
    public class InventoryItemControllerUnitTest
    {
        private Mock<IInventoryItem> itemService;
        [SetUp]
        public void SetUp()
        {
            itemService = new Mock<IInventoryItem>();
        }

        [Test]
        public void GetInventoryItems_Returns_AllInventoryItems()
        {
            // Arrange
            IEnumerable<InventoryItem> fakeItems = GetFakeInventoryItems();
            itemService.Setup(x => x.GetInventoryItems()).Returns(fakeItems.AsQueryable());
            InventoryItemController controller = new InventoryItemController(itemService.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            // Act
            var invItems = controller.GetInventoryItems();

            // Assert
            Assert.IsNotNull(invItems, "Result is null");
            Assert.IsInstanceOf(typeof(IEnumerable<ApiInventoryItem>), invItems, "Wrong Model");
            Assert.AreEqual(3, invItems.Count(), "Got wrong number of Inventory Items");
        }

        [Test]
        public void Get_CorrectInventoryItemID_Returns_InventoryItem()
        {
            // Arrange   
            IEnumerable<InventoryItem> fakeItems = GetFakeInventoryItems();
            itemService.Setup(x => x.GetInventoryItem(1)).Returns(fakeItems.Where(x => x.ID == 1).FirstOrDefault());

            InventoryItemController controller = new InventoryItemController(itemService.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            // Act
            var actionResult = controller.GetInventoryItem(1);
            var contentResult = actionResult as OkNegotiatedContentResult<ApiInventoryItem>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ID, "Got wrong number of Inventory Items");
        }

        [Test]
        public void Get_InValidInventoryItemID_Returns_NotFound()
        {
            // Arrange   
            IEnumerable<InventoryItem> fakeItems = GetFakeInventoryItems();
            itemService.Setup(x => x.GetInventoryItem(5)).Returns(fakeItems.Where(x => x.ID == 5).FirstOrDefault());

            InventoryItemController controller = new InventoryItemController(itemService.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            // Act
            var actionResult = controller.GetInventoryItem(5);
            var contentResult = actionResult as OkNegotiatedContentResult<ApiInventoryItem>;

            // Assert
            Assert.IsNull(contentResult);
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }

        [Test]
        public void PostSetsLocationHeader()
        {
            // Arrange
            InventoryItemController controller = new InventoryItemController(itemService.Object);

            // Act
            IHttpActionResult actionResult = controller.PostInventoryItem(new ApiInventoryItem { ID = 4, Name = "TestItem4", Description = "TestDesc4", Price = 40, ImagePath = "~/Content/Images/test4.jpg" });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<ApiInventoryItem>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(4, createdResult.RouteValues["id"]);
        }

        [Test]
        public void Post_NullInventoryItem_Returns_BadRequest()
        {
            // Arrange
            InventoryItemController controller = new InventoryItemController(itemService.Object);

            // Act
            IHttpActionResult actionResult = controller.PostInventoryItem(null);
            var createdResult = actionResult as NegotiatedContentResult<string>;

            // Assert            
            Assert.IsInstanceOf<NegotiatedContentResult<string>>(createdResult);
            Assert.AreEqual(HttpStatusCode.BadRequest, createdResult.StatusCode);
            Assert.AreEqual("Invalid Request", createdResult.Content);
        }                

        [Test]
        public void DeleteReturnsOk()
        {
            // Arrange    
            IEnumerable<InventoryItem> fakeItems = GetFakeInventoryItems();
            itemService.Setup(x => x.DeleteInventoryItem(1)).Returns(fakeItems.Where(x => x.ID == 1).FirstOrDefault());

            InventoryItemController controller = new InventoryItemController(itemService.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            // Act
            IHttpActionResult actionResult = controller.DeleteInventoryItem(1);
            var contentResult = actionResult as OkNegotiatedContentResult<ApiInventoryItem>;

            // Assert
            Assert.IsInstanceOf<ApiInventoryItem>(contentResult.Content);
        }

        private static IEnumerable<InventoryItem> GetFakeInventoryItems()
        {
            IEnumerable<InventoryItem> fakeItems = new List<InventoryItem>
            {
                    new InventoryItem {ID=1,Name="TestItem1",Description="TestDesc1",Price=10,ImagePath="~/Content/Images/test1.jpg" },
                    new InventoryItem {ID=2,Name="TestItem2",Description="TestDesc2",Price=20,ImagePath="~/Content/Images/test2.jpg" },
                    new InventoryItem {ID=3,Name="TestItem3",Description="TestDesc3",Price=30,ImagePath="~/Content/Images/test3.jpg" }
            }.AsEnumerable();
            return fakeItems;
        }
    }

}
