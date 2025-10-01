using shop.DATA.Entities;
using shop.DATA.Repositories.Interfaces;
using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Shop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> Login(string username, string password)
        {
            User? user = await _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new Exception($"User with username: {username} not found");
            }

            string hash = HashPassword(password);
            if(!user.PasswordHash.Equals(hash))
            {
                throw new Exception("Wrong password!");
            }

            return new UserDto { Username = user.Username };
        }

        public async Task<UserDto> Register(UserDto userDto)
        {
            User user = await _userRepository.GetByUsername(userDto.Username);
            if(user != null)
            {
                throw new Exception("User already exists");
            }

            User newUser = new User
            {
                Username = userDto.Username,
                PasswordHash = HashPassword(userDto.Password),
                Name = userDto.Name,
                Email = userDto.Email,
                Age = Int32.Parse(userDto.Age)
            };

            await _userRepository.AddUser(newUser);

            userDto.Password = "*********";

            return userDto;
        }

        private string HashPassword(string password)
        {
            var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
