using BusinessLogic.SpecificRepository;
using DataAccess.Entities;
using DataAccess.Generic;
using HappyCompanyAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HappyCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ItemController : ControllerBase
    {
        IGeneric<Item> itemGeneric;
        IItemRepository itemRepository;

        public ItemController(IGeneric<Item> _itemGeneric,IItemRepository _itemRepository)
        {
            itemGeneric = _itemGeneric;
            itemRepository = _itemRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public void Insert(ItemDTO item)
        {
            Item entity = new Item();
            entity.Id = item.Id;
            entity.Name = item.Name;
            entity.SKUCode = item.SKUCode;
            entity.Qty = item.Qty;
            entity.CostPrice = item.CostPrice;
            entity.MSRPPrice = item.MSRPPrice;
            entity.Warehouse_Id = item.Warehouse_Id;
            itemGeneric.Insert(entity);
        }
        [HttpGet]
        [Route("LoadAll")]
        public List<Item> LoadAll()
        {
            return itemRepository.LoadAll();
        }
        [HttpGet]
        [Route("Delete")]
        public void Delete(int Id)
        {
            itemGeneric.Delete(Id);
        }
        [HttpPost]
        [Route("Update")]
        public void Update(ItemDTO item)
        {
            Item entity = new Item();
            entity.Id = item.Id;
            entity.Name = item.Name;
            entity.SKUCode = item.SKUCode;
            entity.Qty = item.Qty;
            entity.CostPrice = item.CostPrice;
            entity.MSRPPrice = item.MSRPPrice;
            entity.Warehouse_Id = item.Warehouse_Id;
            itemGeneric.Update(entity);
        }
        [HttpGet]
        [Route("Search")]
        public List<Item> Search(string Name)
        {
            return itemRepository.LoadByName(Name);
        }
        [HttpGet]
        [Route("Edit")]
        public Item Load(int Id)
        {
            return itemGeneric.Load(Id);
        }
        [HttpGet]
        [Route("LoadByWarehouse")]
        public List<Item> LoadByWarehouse(int Id)
        {
            return itemRepository.LoadByWarehouse(Id);
        }
        [HttpGet]
        [Route("LoadTop")]
        public List<Item> LoadTop()
        {
            return itemRepository.LoadTop10();
        }
        [HttpGet]
        [Route("LoadLow")]
        public List<Item> LoadLow()
        {
            return itemRepository.LoadLow10();
        }
    }
}
