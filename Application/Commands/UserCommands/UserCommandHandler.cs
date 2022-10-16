using Application.Interfaces;
using Application.Interfaces.Authentication;
using Domain.Entities.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands
{
    public class UserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandReponse>,
        IRequestHandler<DeleteUserCommand, Unit>,
        IRequestHandler<LoginCommand, LoginCommandResponse>,
        IRequestHandler<LogoutCommand, Unit>
    {
        private readonly IRepository _repository;
        private readonly IUserService _userService;

        public UserCommandHandler(IUserService userService, IRepository repository)
        {
            _userService = userService;
            _repository = repository;
        }

        public async Task<RegisterUserCommandReponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.RegisterAsync(request.User);
            if (user != null)
            {
                return new RegisterUserCommandReponse { User = user };
            }
            return null;
        }

        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _userService.DeleteUserAsync(request.UserId);
            _userService.SignOutAsync();

            return Unit.Task;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.LogInAsync(request.User.Username, request.User.Password);
            return new LoginCommandResponse { User = user };
        }

        public Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            _userService.SignOutAsync();
            return Unit.Task;
        }
    }
}