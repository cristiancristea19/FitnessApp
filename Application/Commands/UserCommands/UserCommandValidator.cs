using Application.Interfaces.Authentication;
using Common.Errors;
using Common.Extensions;
using FluentValidation;
using System;

namespace Application.Commands.UserCommands
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandValidator(IUserService userService)
        {
            _userService = userService;
            RuleFor(x => x.User.Email).Must(BeNotNullOrEmptyString).WithMessage(string.Format(ErrorMessagesNames.STRING_CANNOT_BENULL_OR_EMPTY, "Email"));
            RuleFor(x => x.User.Email).EmailAddress().WithMessage(string.Format(ErrorMessagesNames.INVALID_EMAIL_ADDRESS, "Email"));
            RuleFor(x => x.User.Username).Must(BeNotNullOrEmptyString).WithMessage(string.Format(ErrorMessagesNames.STRING_CANNOT_BENULL_OR_EMPTY, "Username"));
            RuleFor(x => x.User.Username).Must(BeUniqueUsername).WithMessage(string.Format(ErrorMessagesNames.DUPLICATE_ENTITY, "Username"));
            RuleFor(x => x.User.Password).MinimumLength(8).WithMessage(string.Format(ErrorMessagesNames.PASSWORD_TOO_SHORT));
            RuleFor(x => x.User.Password).Must(t => t.MatchPasswordComplexity()).WithMessage(string.Format(ErrorMessagesNames.PASSWORD_DOES_NOT_MATCH_COMPLEXITY));
        }

        private bool BeNotNullOrEmptyString(string arg)
        {
            return !string.IsNullOrEmpty(arg);
        }

        public bool BeUniqueUsername(string username)
        {
            return _userService.IsUsernameUniqueAsync(username).Result;
        }
    }

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandValidator(IUserService userService)
        {
            _userService = userService;
            RuleFor(x => x.UserId).Must(Exist).WithMessage(string.Format(ErrorMessagesNames.NOT_FOUND, "User"));
        }

        public bool Exist(Guid id)
        {
            return _userService.ExistsUserAsync(id).Result;
        }
    }
}