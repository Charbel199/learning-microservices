using System.Threading.Tasks;
using MailService.Dtos;
using MailService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MailService.Controllers
{
    [Route("api/mail")]
    [ApiController]
    public class EmailController: ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(
            IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("send")]
        public IActionResult SendMail(SendMailDto mail)
        {
            return Ok(_emailService.sendEmail(mail));
        }
    }
    
    
}