using System;
using ClassLibrary.Implementation;
using ClassLibrary.Interface;
using ClassLibrary.Models;

namespace ClassLibrary.Controller
{
    public class UserController
{
    private readonly IUser _userImplementation;

    public UserController(IUser userImplementation)
    {
        _userImplementation = userImplementation;
    }

    public void AddUser(string userName, int phoneNumber)
    {
        _userImplementation.AddUser(userName, phoneNumber);
    }

    public void RemoveUser(string userName)
    {
        _userImplementation.RemoveUser(userName);
    }

    public void GetUser(string userName)
    {
        _userImplementation.GetUser(userName);
    }
}

}