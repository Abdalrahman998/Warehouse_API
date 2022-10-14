using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public interface ICountryRepository
    {
        List<Country> LoadByName(string Name);
    }
}
