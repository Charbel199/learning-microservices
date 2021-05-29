namespace MailService.Dtos
{
    public class SendMailDto
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; } 
    }
}