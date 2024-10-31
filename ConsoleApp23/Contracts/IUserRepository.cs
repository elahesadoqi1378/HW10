using ConsoleApp23.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23.Contracts
{
    public interface IUserRepository
    {
        List<User> LoadUsers();
        void SaveUsers(List<User> users);
        User FindUser(string username);
        void AddUser(User user);
    }
}
