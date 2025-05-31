using System;
using ClassLibrary.Models;

namespace ClassLibrary.Interface
{
    public interface IUser
    {
         void AddUser(string UserName, int PhoneNumber);
         void RemoveUser(string userName);
         void GetUser(string userName);
        
    }
}