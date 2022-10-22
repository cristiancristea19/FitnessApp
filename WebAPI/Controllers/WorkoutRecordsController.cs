using Application.Commands.WorkoutRecordCommands;
using Application.Queries.WorkoutQueries;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkoutRecordsController : BaseController
    {
        private readonly IOptions<Logging> _logger;

        public WorkoutRecordsController(IOptions<Logging> logger)
        {
            _logger = logger;
        }

        [HttpPost("AddWorkoutRecord")]
        [AllowAnonymous]
        public async Task<IActionResult> AddWorokoutRecord([FromBody] AddWorkoutRecordCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("GetWorkoutRecords/{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetWorkoutRecords([FromRoute] string userId)
        {
            return Ok(await Mediator.Send(new GetWorkoutRecordsQuery { UserId = userId}));
        }

        [HttpGet("FilterByActivityType/{userId}/{activityType}")]
        [AllowAnonymous]
        public async Task<IActionResult> FilterByActivityType([FromRoute] string userId, int activityType)
        {
            return Ok(await Mediator.Send(new FilterByActivityTypeQuery { UserId = userId, ActivityType = activityType}));
        }
    }
}
