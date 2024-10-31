

using ConsoleApp23.Contracts;
using ConsoleApp23.DataBase;
using ConsoleApp23.Entities;
using Newtonsoft.Json;

namespace ConsoleApp23.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> LoadUsers()
        {
            if (!File.Exists(FileDatas.FilePath))
            {
                return new List<User>();
            }

            var txtData = File.ReadAllText(FileDatas.FilePath);
            return JsonConvert.DeserializeObject<List<User>>(txtData); //tabdil az text be object
        }
        public void SaveUsers(List<User> users)
        {
            var txtdata = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(FileDatas.FilePath, txtdata);
        }
        public User FindUser(string username)
        {
            return LoadUsers().Find(user => user.UserName == username);
        }
        public void AddUser(User user)
        {
            var users = LoadUsers();
            users.Add(user);
            SaveUsers(users);

        }
    }
}
