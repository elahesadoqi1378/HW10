
using ConsoleApp23.Entities;
using ConsoleApp23.Repositories;

namespace ConsoleApp23.Services
{
    public class UserService
    {
        private static UserRepository _userRepository;
        public User LoggedInUser { get; private set; }

        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public string Register(string username , string password)
        {
            var existingUser = _userRepository.FindUser(username);
            if (existingUser != null)
            {
                throw new Exception( "Registration failed! username already exists.");
            }
            var newUser = new User { UserName = username, Password = password }; //yek object jadid misazim
            _userRepository.AddUser(newUser);
            return "Registration was successful!";
        }
        public string login(string username , string password)
        {
            var User = _userRepository.FindUser(username);
            if(User == null)
            
                throw new Exception( "Login failed ! first you have to Register");

            if (User.Password != password)

                throw new Exception( "Login failed ! incorrect password");
            LoggedInUser = User;
            return "Login Successful";
        }
        public string ChangeStatus(string status)
        {
            if(LoggedInUser == null)
            {
                throw new Exception( "Error! you must be logged in to change status");
            }
            //change status
            LoggedInUser.Status = status.ToLower() == "available" ? "available" : "not available";
            //load existing users 
            var users = _userRepository.LoadUsers();
            
            var index = users.FindIndex(user => user.UserName.ToLower() == LoggedInUser.UserName.ToLower());
            if(index != -1)
            {
                users[index] = LoggedInUser;
                _userRepository.SaveUsers(users);
            }
            return $"Status changed to : {LoggedInUser.Status}";
        }
        public List<User> Search(string pre)
        {
            if (LoggedInUser == null)
                throw new Exception("Error! you must first logged in to search ");
            var users = _userRepository.LoadUsers();
            return users.FindAll(user => user.UserName.ToLower().StartsWith(pre.ToLower()));

        }
        public string ChangePassword(string oldpassword , string newpassword)
        {
            if (LoggedInUser == null)
                throw new Exception( "Error! you must first logged in to change your password ");

            if (LoggedInUser.Password != oldpassword)
                throw new Exception ("Error! old password is incorrect.");

            LoggedInUser.Password = newpassword;
            var users = _userRepository.LoadUsers();
            var index = users.FindIndex(user => user.UserName.ToLower() == LoggedInUser.UserName.ToLower());
            if (index != -1)
            {
                users[index] = LoggedInUser;
                _userRepository.SaveUsers(users);
            }
          
            return "Password Changed successfully";

        }
        public string LogOut()
        {
            LoggedInUser = null;
            return "Logged out successfully!";
        }
    }
}

