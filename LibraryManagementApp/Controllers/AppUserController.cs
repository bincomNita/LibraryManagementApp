using LibraryManagementApp.Model;
using LibraryManagementApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AppUserController(IAppUserRepository appUserRepository) : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository=appUserRepository;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AppUser user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _appUserRepository.Login(user);
                return Ok(_appUserRepository.GenerateJwtToken(user));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AppUser user)
        {
            var result = await _appUserRepository.Register(user);

            if (result == "User already exists!")
                return BadRequest(result);

            return Ok(result);
        }
    }
}
