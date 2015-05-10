using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Infrastructure
{
    public class UsersRepository
    {
        private List<User> users;

        public UsersRepository(List<User>usersList)
        {
            users = usersList;
        }
        public User GetUser(string username)
        {
            var index = users.FindIndex(u => u.Username == username);
            if (index != -1)
            {
                return users[index];
            }
            else
            {
                var user = new User(username);
                users.Add(user);

                return user;
            }
        }
    }
}
