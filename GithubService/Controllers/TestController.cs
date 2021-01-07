using GithubService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GithubService.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController: ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public TestController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        
        [HttpGet]
        public ActionResult<string> Gettest()
        {
            
            return Ok(_projectRepository.GetAllProjects());
        } 
    }
    
}