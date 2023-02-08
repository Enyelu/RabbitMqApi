using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RabitMqApi.Models.Dto;
using RabitMqApi.Services.Interfaces;

namespace RabitMqApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUser _user;

        public UserController(ILogger<UserController> logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _logger.LogInformation($"Attempting to add a new user: {JsonSerializer.Serialize(user)}");

            try
            {
                return Ok(_user.AddUser(user));
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error: {error.Message}. Inner exception: {error.InnerException}");
                throw new Exception(error.Message);
            }
        }
    }
}