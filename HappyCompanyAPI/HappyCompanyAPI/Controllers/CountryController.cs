using BusinessLogic.SpecificRepository;
using DataAccess.Entities;
using DataAccess.Generic;
using HappyCompanyAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CountryController : ControllerBase
    {
        IGeneric<Country> countryGeneric;
        ICountryRepository countryRepository;

        public CountryController(IGeneric<Country> _countryGeneric,ICountryRepository _countryRepository)
        {
            countryGeneric = _countryGeneric;
            countryRepository = _countryRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public void Insert(CountryDTO country)
        {
            Country entity = new Country();
            entity.Id = country.Id;
            entity.Name = country.Name;
            countryGeneric.Insert(entity);
        }
        [HttpGet]
        [Route("LoadAll")]
        public List<Country> LoadAll()
        {
            return countryGeneric.LoadAll();
        }
        [HttpGet]
        [Route("Delete")]
        public void Delete(int Id)
        {
            countryGeneric.Delete(Id);
        }
        [HttpPost]
        [Route("Update")]
        public void Update(CountryDTO country)
        {
            Country entity = new Country();
            entity.Id = country.Id;
            entity.Name = country.Name;
            countryGeneric.Update(entity);
        }
        [HttpGet]
        [Route("Search")]
        public List<Country> Search(string Name)
        {
            return countryRepository.LoadByName(Name);
        }
        [HttpGet]
        [Route("Edit")]
        public Country Load(int Id)
        {
            return countryGeneric.Load(Id);
        }
    }
}
