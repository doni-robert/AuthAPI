// using System.Net;
// using System.Net.Mail;

// namespace ATSBackend.Services;

// public interface IEmailSender
// {
//     Task SendEmailAsync(string email, string subject, string message);
// }

// public class EmailSender : IEmailSender
// {
//     private readonly IConfiguration _config;

//     public EmailSender(IConfiguration config)
//     {
//         _config = config;
//     }

//     public async Task SendEmailAsync(string email, string subject, string message)
//     {
//         Console.WriteLine($"Host: {_config["Email:Host"]}");
//         Console.WriteLine($"Port: {_config["Email:Port"]}");
//         Console.WriteLine($"Username: {_config["Email:Username"]}");
//         var smtpClient = new SmtpClient(_config["Email:Host"])
//         {
//             Port = int.Parse(_config["Email:Port"]),
//             Credentials = new NetworkCredential(_config["Email:Username"], _config["Email:Password"]),
//             EnableSsl = true
//         };

//         await smtpClient.SendMailAsync(
//             new MailMessage(_config["Email:FromAddress"], email, subject, message) 
//             { IsBodyHtml = true }
//         );
//     }
// }
