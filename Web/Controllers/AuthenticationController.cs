using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Models.Request;

namespace Web.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IConfiguration config, IAuthenticationService autenticacionService)
        {
            _config = config;
            _authenticationService = autenticacionService;
        }
        [HttpPost("authenticate")] 
        public ActionResult<string> Autenticar(AuthenticationRequest authenticationRequest) 
        {
            string token = _authenticationService.Autenticar(authenticationRequest); 
            if(token == null)
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(token);
        }
    }
}
