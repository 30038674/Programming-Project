using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMCServer
{
    class User
    {
        private string userPass;
        private string userName;
        private string userHashedPassword;

        public User() { }

        public User(string user, string password, string hashedpassword) 
        {
            userName = user;
            userPass = password;
            userHashedPassword = hashedpassword;
        }

        public string getPassword()
        {
            return this.userPass;
        }
        public string getUser()
        {
            return this.userName;
        }
        public string GetHashedPassword()
        {
            return this.userHashedPassword;
        }
    }
}
