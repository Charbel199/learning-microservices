using System.Threading.Tasks;
using GithubService.Models.RequestModels.QueryRequestModels;
using GithubService.Models.ResponseModels.QueryResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GithubService.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class ProjectController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("project")]
        public async Task<IActionResult> GetProjectById([FromQuery] GetProjectByIdRequestModel requestModel)
        {
            var response =  await _mediator.Send(requestModel);
            return Ok(response);
        }
        
        [HttpGet("projects")]
        public async Task<IActionResult> GetAllProjects([FromQuery] GetAllProjectsRequestModel requestModel)
        {
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }
        
        [HttpPost("test")]
        public async Task<IActionResult> test()
        {
            return Ok(new JsonResult("Nice", "nice"));
        }
        
    }
}