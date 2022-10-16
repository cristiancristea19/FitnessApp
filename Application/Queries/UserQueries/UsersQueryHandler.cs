using Application.Interfaces.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.UserQueries
{
    public class UsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersQueryResponse>
    {
        private readonly IUserService _userService;

        public UsersQueryHandler(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<GetUsersQueryResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetUsersAsync();
            return new GetUsersQueryResponse { Users = users };
        }
    }
}