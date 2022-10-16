using MediatR;
using Application.Common;
using Application.Models.AuthenticationModels;
using System;

namespace Application.Commands.UserCommands
{
    public class RegisterUserCommand : BaseRequest<RegisterUserCommandReponse>
    {
        public RegisterUserModel User { get; set; }
    }

    public class RegisterUserCommandReponse
    {
        public UserModel User { get; set; }
    }

    public class DeleteUserCommand : BaseRequest<Unit>
    {
        public Guid UserId { get; set; }
    }

    public class LoginCommand : BaseRequest<LoginCommandResponse>
    {
        public LoginUserModel User { get; set; }
    }

    public class LoginCommandResponse
    {
        public UserModel User { get; set; }
    }

    public class LogoutCommand : BaseRequest<Unit>
    {

    }
}