using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public class CountryRepository:ICountryRepository
    {
        SystemContext context;

        public CountryRepository(SystemContext _context)
        {
            context = _context;
        }
        public List<Country> LoadByName(string Name)
        {
            int l = Name.Length;
            return context.countries.Where(c => c.Name.Substring(0, l) == Name).ToList();
        }
    }
}
