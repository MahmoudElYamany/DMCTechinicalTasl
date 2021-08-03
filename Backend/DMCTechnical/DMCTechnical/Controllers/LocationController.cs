using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCTechnical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocation _dB;

        public LocationController(ILocation db)
        {
            _dB = db;
        }


        // GET: api/City/5
        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            return Ok(await _dB.GetbycityId(id.ToString()));
        }

        // GET: api/City/id
        [HttpGet("cityBYcounty/{countryid}")]
        public async Task<IActionResult> SelCityByCountryID(int countryid)
        {
            var cities = await _dB.SelCityByCountryID(countryid);
            return Ok(cities);
        }

        // GET: api/Country
        [HttpGet("Country")]
        public async Task<IActionResult> GetCountry()
        {
            var countries = await _dB.GetAllcountries();
            return Ok(countries);
        }

        // GET: api/Country/5
        [HttpGet("Country/{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            return Ok(await _dB.GetbycountryId(id));
        }
        [HttpGet("getCities")]
        public IActionResult getCities()
        {
            return Ok(_dB.GetAllcities());
        }
    }
}
