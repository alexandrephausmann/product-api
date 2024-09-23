using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // Injeção da nossa interface para geração de Token
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Generates a JWT token to use in all endpoints
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var token = _tokenService.GetToken(user);

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
