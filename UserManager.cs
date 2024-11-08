using System;
using System.Collections.Generic;

namespace Project_KTMH
{
    public class UserManager
    {
        public static User loggedIn_User { get; set; }
        private static UserManager instance;
        private List<User> users;

        public static string getID()
        {
            return loggedIn_User.Password;
        }

        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }

        public static Employee GetEmployee()
        {
            foreach((Employee,Payroll)ep in EmployeeList.emp)
            {
                if(getID() == ep.Item1.EmployeeID1)
                {
                    return ep.Item1 ;
                }
            }
            return null ;
        }

        private UserManager()
        {
            users = new List<User>();
        }
        
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public List<User> GetUsers()
        {
            return users;
        }
        public bool Login(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.Login(username, password))
                {
                    loggedIn_User = user; 
                    return true;
                }
            }
            Console.WriteLine("Tên đăng nhập hoặc mật khẩu không đúng.");
            return false;
        }
    }
}
