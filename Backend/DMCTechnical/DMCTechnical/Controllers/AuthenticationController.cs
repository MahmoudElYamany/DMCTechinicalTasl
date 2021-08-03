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
    public class AuthenticationController : ControllerBase
    {
        private Iauth _auth;

        public AuthenticationController(Iauth auth)
        {
            _auth = auth;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> Register([FromBody] RegisterModel rm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.RegisterAsync(rm);
            return Ok(res);
        }
        [HttpPost("AdminSignUp")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel rm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.RegisterAsyncAdmin(rm);
            return Ok(res);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInModel lm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.LogInAsync(lm);
            return Ok(res);
        }
    }
}
