using Microsoft.AspNetCore.Mvc;
using RabitMqApi.Models.Entities;

namespace RabitMqApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            return default;
        }
    }
}