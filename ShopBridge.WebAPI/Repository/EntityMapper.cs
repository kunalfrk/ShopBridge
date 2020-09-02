using AutoMapper;
using ShopBridge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBridge.WebAPI.Models;

namespace ShopBridge.WebAPI.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<ApiInventoryItem, InventoryItem>();
            Mapper.CreateMap<InventoryItem, ApiInventoryItem>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}