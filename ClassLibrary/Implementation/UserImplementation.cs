using System;
using ClassLibrary.Interface;
using ClassLibrary.Models;

namespace ClassLibrary.Implementation
{
    public class UserImplementation:IUser
    {
        List<User>users= new List<User>();
        public void AddUser(string UserName, int PhoneNumber)
        {
            users.Add(new User { UserName = UserName, PhoneNumber = PhoneNumber });
        }

        public void RemoveUser(string userName)
        {
            var user = users.FirstOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine($"User {userName} removed successfully.");
            }
            else
            {
                Console.WriteLine($"User {userName} not found.");
            }
        }

        public void GetUser(string userName)
        {
            var user = users.FirstOrDefault(u => u.UserName == userName);

            Console.WriteLine($"User {userName} details");
            
        }
    }
}