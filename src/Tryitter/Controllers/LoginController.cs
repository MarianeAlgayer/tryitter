using Tryitter.Context;
using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using Tryitter.Repository;
using Tryitter.Services;

namespace Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<LoginViewModel> Authenticate([FromBody] Login login)
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                loginViewModel.Login  = new StudentRepository(_context).GetStudent(login);

                if(loginViewModel.Login == null)
                {
                    return NotFound("Student não encontrado!");
                }

                loginViewModel.Token = new TokenGenerator().Generate(login);
                loginViewModel.Login.Password = string.Empty;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return loginViewModel;
        }
    }
}