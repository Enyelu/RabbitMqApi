using RabitMqApi.Data;
using RabitMqApi.Services.Interfaces;
using UserDto = RabitMqApi.Models.Dto;
using NewUser = RabitMqApi.Models.Entities;

namespace RabitMqApi.Services.Implementations
{
    public class User : IUser
    {
        private readonly IMessagePublisher _messagePublisher;
        public User(IMessagePublisher messagePublisher)
        {
                _messagePublisher = messagePublisher;
        }
        public NewUser.User AddUser(UserDto.User user)
        {
            var newUser =  new NewUser.User
            {
                FirtName = user.FirtName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
            };

            Storage.Users.Add(newUser);
            _messagePublisher.Publish(newUser);

            return newUser;
        }
    }
}
