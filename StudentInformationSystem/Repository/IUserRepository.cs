using StudentInformationSystem.Models;
using StudentInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public interface IUserRepository
    {
        Task AddUser(Users user);
        Task<bool> IsUserExist(Users user);

        Task<bool> IsValidUser(LoginViewModel user);
    }
}
