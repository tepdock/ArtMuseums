using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtMuseums.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(ILoggerManager logger, IMapper mapper, 
            UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }

        /// <summary>
        ///     Register
        /// </summary>
        /// <param name="userForRegistration"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto
            userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }
            IEnumerable<string> roles = System.Array.Empty<string>();
            roles.Append(userForRegistration.Roles);
            await _userManager.AddToRolesAsync(user, roles);

            return StatusCode(201);
        }

        /// <summary>
        ///     login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto 
            user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.Warn($"{nameof(Authenticate)}: Authentication failed. Wrong username or password");
                return Unauthorized();
            }

            return Ok(new {Token = await _authManager.CreateToken()});
        }
    }
}
