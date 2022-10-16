using Application.Commands.UserCommands;
using Application.Queries.UserQueries;
using Domain.Entities;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers.Base;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        private readonly IOptions<Logging> _logger;

        public AccountsController(IOptions<Logging> logger)
        {
            _logger = logger;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand model)
        {
            var response = await Mediator.Send(model);
            if (response.User == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            return Ok(await Mediator.Send(new LogoutCommand()));
        }

        [HttpPost("RegisterUserRequest")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("Users")]
        [AllowAnonymous]
        public async Task<ActionResult<GetUsersQueryResponse>> GetUsers()
        {
            return Ok(await Mediator.Send(new GetUsersQuery { }));
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<GetUserDetailsQueryResponse>> GetById([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetUserDetailsQuery { UserId = id }));
        }

        [HttpDelete("User/{id}")]
        [AuthorizeEnum(RoleTypeEnum.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { UserId = id }));
        }
    }
}