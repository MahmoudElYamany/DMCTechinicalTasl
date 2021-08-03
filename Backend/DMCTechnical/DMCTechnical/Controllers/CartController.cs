using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCTechnical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _dB;

        public CartController(ICart db)
        {
            _dB = db;
        }

        [HttpGet("Status")]
        public async Task<IActionResult> GetAllStatus()
        {
            var result = await _dB.GetAllStatus();
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpGet("Discount/{id}")]
        public async Task<IActionResult> GetVAlueDiscount(string id)
        {
            var result = await _dB.GetVAlueDiscount(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpGet("noInvoice/{id}")]
        public async Task<IActionResult> GetInvoiceno(string id)
        {
            var result = await _dB.GetInvoiceno(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> AddToCart(CartModel cm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _dB.checkout(cm);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpGet("Invoice/{id}")]
        public async Task<IActionResult> InvoiceDetials(string id)
        {
            var result = await _dB.InvoiceDetials(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);

        }
    }
}
