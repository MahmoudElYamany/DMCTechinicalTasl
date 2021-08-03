using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ILocation
    {
        Task<List<Country>> GetAllcountries();
        Task<Country> GetbycountryId(int id);
        Task<List<City>> GetAllcities();
        Task<City> GetbycityId(string id);
        Task<List<City>> SelCityByCountryID(int countryid);

    }
}
