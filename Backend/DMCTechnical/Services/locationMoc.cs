using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class locationMoc :ILocation
    {
        private readonly ApiContext _db;

        public locationMoc(ApiContext db)
        {
            _db = db;
        }
        public async Task<List<Country>> GetAllcountries()
        {
            return await _db.countries.ToListAsync();
        }
        public async Task<Country> GetbycountryId(int id)
        {
            return await _db.countries.FirstOrDefaultAsync(x => x.country_id == id);
        }

        public async Task<List<City>> GetAllcities()
        {
            return await _db.cities.Include(a => a.country).ToListAsync();
        }
        public async Task<City> GetbycityId(string id)
        {
            return await _db.cities.Where(a => a.City_Id == int.Parse(id)).FirstOrDefaultAsync();
        }
        public async Task<List<City>> SelCityByCountryID(int countryid)
        {
            var city = await _db.cities.Where(a => a.country.country_id == countryid).ToListAsync();
            return city;
        }
    }
}
