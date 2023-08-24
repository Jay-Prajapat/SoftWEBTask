using StudentInformationSystem.DAL;
using StudentInformationSystem.Models;
using StudentInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentInformationSystem.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly StudentDBEntity _dbContext;
        public UserRepository()
        {
            _dbContext = StudentDataAccess.GetInstance();
        }
        public async Task AddUser(Users user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsUserExist(Users user)
        {
            return await _dbContext.Users.AnyAsync(u => u.UserName.Equals(user.UserName) || u.Email.Equals(user.Email));
        }

        public async Task<bool> IsValidUser(LoginViewModel user)
        {
            return await _dbContext.Users.AnyAsync(u => u.UserName == user.UserName && u.Password == user.Password);
        }

    }
}