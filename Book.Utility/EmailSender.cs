using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace Book.Utility;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var emailToSend = new MimeMessage();
        emailToSend.From.Add(MailboxAddress.Parse("kdacoder@gmail.com"));
        emailToSend.To.Add(MailboxAddress.Parse(email));
        emailToSend.Subject = subject;
        emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

        using (var emailClinet = new SmtpClient())
        {
            emailClinet.Connect("smtp.gmail.com",587,MailKit.Security.SecureSocketOptions.StartTls);
            emailClinet.Authenticate("kdacoder@gmail.com","------");
            emailClinet.Send(emailToSend);
            emailClinet.Disconnect(true);

        }
        
        return Task.CompletedTask;
    }
    
}