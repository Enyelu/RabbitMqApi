using UserDto = RabitMqApi.Models.Dto;
using NewUser = RabitMqApi.Models.Entities;

namespace RabitMqApi.Services.Interfaces
{
    public interface IUser
    {
        NewUser.User AddUser(UserDto.User user);
    }
}
