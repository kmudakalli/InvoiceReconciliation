using System.Net.Mail;

namespace InvoiceReconciliationApi.Services
{
    public class EmailService
    {
        private readonly SmtpClient _smtp;
        private readonly string _from;

        public EmailService(IConfiguration cfg)
        {
            _smtp = new SmtpClient(cfg["Email:SmtpHost"], int.Parse(cfg["Email:SmtpPort"]));
            _from = cfg["Email:From"];
        }

        public Task SendAsync(string to, string subject, string body)
            => _smtp.SendMailAsync(_from, to, subject, body);
    }
}