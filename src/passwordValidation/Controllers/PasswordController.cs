using Microsoft.AspNetCore.Mvc;
using passwordValidation.Interfaces.Handlers;

namespace passwordValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordValidationHandler _passwordValidationHandler;

        public PasswordController(IPasswordValidationHandler passwordValidationHandler)
        {
            _passwordValidationHandler = passwordValidationHandler;
        }

        [HttpGet]
        [Route("validate")]
        public IActionResult Validate(string password)
        {
            var isValid = _passwordValidationHandler.Validate(password);

            return isValid ? Ok(isValid): (IActionResult)BadRequest(isValid);
        }
    }
}
