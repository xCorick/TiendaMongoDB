using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using TiendaMondo.Model;
using TiendaMongo.Data.Interfaces;
using TiendaMongo.Data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserServices _userServices;

        public UserController(ILogger<UserController> logger, UserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var user = await _userServices.FindAll();
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("Correo/{correo}")]
        public async Task<IActionResult> FindByEmail(string correo)
        {
            var user = await _userServices.FindByEmail(correo);
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            await _userServices.CreateUser(user);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("Correo/{correo}")]
        public async Task<IActionResult> DeleteByEmail(string correo)
        {
            if(correo == null)
                return BadRequest();
            if (correo == string.Empty)
                ModelState.AddModelError("correo", "El correo no debe ir vacio");

            await _userServices.DeleteByEmail(correo);
            return Ok();
        }
    }
}
