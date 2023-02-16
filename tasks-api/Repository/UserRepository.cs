using Microsoft.EntityFrameworkCore;
using tasks_api.Data;
using tasks_api.Models;
using tasks_api.Repository.Interfaces;

namespace tasks_api.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext taskSystemDBContext) {
            _dbContext = taskSystemDBContext;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
           await _dbContext.Users.AddAsync(user);
           await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userId = await GetUserById(id);

            if (userId == null)
            {
                throw new Exception("User doesn't exists");
            }
            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
          UserModel userId =  await GetUserById(id);

            if(userId == null) {
                throw new Exception("User doesn't exists");
            }
            userId.Name = user.Name;
            userId.Email = user.Email;
            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }
    }
}
