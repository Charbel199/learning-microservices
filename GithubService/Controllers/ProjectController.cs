using GithubService.Models.RequestModels.QueryRequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GithubService.Controllers
{
    [Route("api2/test")]
    [ApiController]
    public class ProjectController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("project")]
        public IActionResult GetProjectById([FromQuery] GetProjectByIdRequestModel requestModel)
        {
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }
        
        
        
        
        
    }
}