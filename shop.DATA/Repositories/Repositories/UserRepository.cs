using Microsoft.EntityFrameworkCore;
using shop.DATA.Entities;
using shop.DATA.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.DATA.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            User testUser = await GetByUsername(user.Username);
            if (testUser != null)
            {
                throw new Exception($"User with username: {user.Username} already created");
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByUsername(string username)
        {
            User user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username.Equals(username));

            if(user == null)
            {
                throw new Exception($"User with username: {username} not found");
            }

            return user;
        }
    }
}
