using ConsoleApp23.Services;

class Program
{
    static void Main(string[] args)
    {
        UserService userService = new UserService();

        while (true)
        {
            Console.WriteLine("Enter a command:(register/login/search/change/changepassword/logout)");
            var command = Console.ReadLine();
            var parts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) continue;
            try
            {
                switch (parts[0].ToLower())
                {
                    case "register":
                        if (parts.Length ==5 && parts[1] == "--username" && parts[3] == "--password")
                        {
                            var usernamee = parts[2];
                            var passwordd = parts[4];
                            Console.WriteLine(userService.Register(usernamee, passwordd));
                            
                        }
                        else
                        {
                            Console.WriteLine("Usage: register --username username --password password");
                            break;
                        }
                       
                        break;
   
                    case "login":
                        if (parts.Length == 5 && parts[1] == "--username" && parts[3] == "--password")
                        {

                            var username = parts[2];
                            var password = parts[4];
                            Console.WriteLine(userService.login(username, password));
                        }
                        else
                        {
                            Console.WriteLine("Usage: login --username username --password password");
                            break;
                        }
                        
                        break;
                    case "change":
                        if (parts.Length == 3 && parts[1] == "--status")
                        {
                            var status = parts[2];
                            Console.WriteLine(userService.ChangeStatus(status));
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Usage: change --status status");

                        }
                        break;
                    case "search":
                        //if (parts.Length ==2 && parts[1] == "--username")
                        //{
                            var prefix = parts[2];
                            var result = userService.Search(prefix);
                            foreach (var user in result)
                            {
                                Console.WriteLine(user.UserName + "status is : " + user.Status);
                              
                            }
                        break;

                    //}
                    //else
                    //{
                    //    Console.WriteLine("Usage: search --username pre");  
                    //}


                    case "changepassword":
                        if (parts.Length == 5 && parts[1] == "--old" && parts[3]=="--new")
                        {
                            var oldPassword = parts[2];
                            var newPassword = parts[4];
                            Console.WriteLine(userService.ChangePassword(oldPassword, newPassword));
                            
                        }
                        else
                        {
                            Console.WriteLine("Usage: changepassword --old oldPassword --new newPassword");
                        }

                        break;

                    case "logout":
                        Console.WriteLine(userService.LogOut());
                        break;

                    default:
                        Console.WriteLine("UnKnown command");
                        break;




                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception:{ex.Message}");
            }
        }

    }
    

    


}