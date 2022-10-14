using BusinessLogic.SpecificRepository;
using DataAccess.Entities;
using DataAccess.Generic;
using DataAccess.Model;
using HappyCompanyAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class WarehouseController : ControllerBase
    {
        IGeneric<Warehouse> warehouseGeneric;
        IWarehouseRepository warehouseRepository;

        public WarehouseController(IGeneric<Warehouse> _warehouseGeneric, IWarehouseRepository _wharehouseRepository)
        {
            warehouseGeneric = _warehouseGeneric;
            warehouseRepository = _wharehouseRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public void Insert(WarehouseDTO warehouse)
        {
            Warehouse entity = new Warehouse();
            entity.Id = warehouse.Id;
            entity.Name = warehouse.Name;
            entity.Address = warehouse.Address;
            entity.City = warehouse.City;
            entity.Country_Id = warehouse.Country_Id;
            warehouseGeneric.Insert(entity);
        }
        [HttpGet]
        [Route("LoadAll")]
        public List<Warehouse> LoadAll()
        {
            return warehouseRepository.LoadAll();
        }
        [HttpGet]
        [Route("Delete")]
        public void Delete(int Id)
        {
            warehouseGeneric.Delete(Id);
        }
        [HttpPost]
        [Route("Update")]
        public void Update(WarehouseDTO warehouse)
        {
            Warehouse entity = new Warehouse();
            entity.Id = warehouse.Id;
            entity.Name = warehouse.Name;
            entity.Address = warehouse.Address;
            entity.City = warehouse.City;
            entity.Country_Id = warehouse.Country_Id;
            warehouseGeneric.Update(entity);
        }
        [HttpGet]
        [Route("Search")]
        public List<Warehouse> Search(string Name)
        {
            return warehouseRepository.LoadByName(Name);
        }
        [HttpGet]
        [Route("Edit")]
        public Warehouse Load(int Id)
        {
            return warehouseGeneric.Load(Id);
        }
        [HttpGet]
        [Route("LoadTotalItems")]
        public List<WarehouseWithTotalItems> LoadTotalItems()
        {
            return warehouseRepository.LoadWithTotalItems();
        }
    }
}
