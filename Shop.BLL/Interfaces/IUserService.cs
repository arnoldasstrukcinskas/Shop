using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> Login(string username, string password);
        Task<UserDto> Register(UserDto userDto);
    }
}
