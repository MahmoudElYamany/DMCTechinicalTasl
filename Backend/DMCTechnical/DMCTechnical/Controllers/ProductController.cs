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
    public class ProductController : ControllerBase
    {
        private readonly IProduct _dB;

        public ProductController(IProduct db)
        {
            _dB = db;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> getProducts()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _dB.GetAllProducts();
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
    }
}
