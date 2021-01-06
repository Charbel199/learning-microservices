using Microsoft.AspNetCore.Mvc;

namespace GithubService.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController: ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Gettest()
        {
          
            return Ok("Nice2");
        } 
    }
    
}