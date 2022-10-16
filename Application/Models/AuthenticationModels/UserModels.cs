using System;
using System.Collections.Generic;

namespace Application.Models.AuthenticationModels
{
    public class RegisterUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Password { get; set; }
        public RegisterRoleModel Role { get; set; }
    }

    public class LoginUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}