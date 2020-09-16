using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Entities;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authrepository;
        public AuthController(IAuthRepository authRepository)
        {
            this.authrepository = authRepository;

        }
        [HttpPost]
        public async  Task<IActionResult> Register([FromBody] UserDataObject userDataObject)
        {
            userDataObject.UserName= userDataObject.UserName.ToLower();
            if(await authrepository.UserExists(userDataObject.UserName))
            {
                return BadRequest("User Already Exists in the System");
            }
           
            var userCreated = new User
            {
            Username=userDataObject.UserName
            };

            var createdUser= await authrepository.Register(userCreated,userDataObject.Password);
            return StatusCode(201);
        }

        // [HttpPost]
        // public async  Task<IActionResult> Login(string Username, string Password)
        // {
        //      var values=await this._context.values.ToListAsync();
        //     return Ok(values);
        // }
    }
}