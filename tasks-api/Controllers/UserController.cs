using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tasks_api.Models;

namespace tasks_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            return Ok();
        }
    }
}
