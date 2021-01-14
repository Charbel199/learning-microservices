using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailService.Dtos;
using Microsoft.Extensions.Configuration;

namespace MailService.Services
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public SendMailDto sendEmail(SendMailDto mail)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_config["EmailSender"]);
                mailMessage.To.Add(_config["EmailReceiver"]);
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = mail.Subject;
                
                string content = "Name: " + mail.Name;
                content += "<br/> Address: " + mail.EmailAddress;
                content += "<br/> Message: " + mail.Message;
                Console.WriteLine("Content " + content);
                mailMessage.Body = content;
                
                SmtpClient smtpClient = new SmtpClient(" smtp.gmail.com");
                smtpClient.Port = 587;
                NetworkCredential networkCredential = new NetworkCredential(_config["EmailSender"],_config["EmailSenderPassword"]);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.EnableSsl = true;
              
                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine("In exception");
                Console.WriteLine(e);
            }

            return mail;
        }
    }
}