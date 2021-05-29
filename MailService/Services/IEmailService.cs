using System.Threading.Tasks;
using MailService.Dtos;

namespace MailService.Services
{
    public interface IEmailService
    {
        SendMailDto sendEmail(SendMailDto mail);
    }
}