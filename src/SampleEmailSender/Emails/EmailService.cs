using Microsoft.Extensions.Options;

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace SampleEmailSender.Emails;

public sealed class EmailService : IEmailService
{
    private readonly EmailOptions _emailOptions;

    public EmailService(IOptions<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }

    public async Task SendEmail(SendEmailRequest input)
    {
        var email = CreateEmail(input);

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(_emailOptions.Host, _emailOptions.Port, SecureSocketOptions.StartTls);

        await smtp.AuthenticateAsync(_emailOptions.EmailOfSender, _emailOptions.Password);

        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }

    private MimeMessage CreateEmail(SendEmailRequest input)
    {
        var email = new MimeMessage
        {
            Sender = MailboxAddress.Parse(_emailOptions.EmailOfSender),
            Subject = input.Subject,
        };

        email.To.Add(MailboxAddress.Parse(input.EmailOfReceiver));

        var builder = new BodyBuilder();

        AddAttachmentsTo(builder, input.Attachments);

        builder.HtmlBody = input.Body;

        email.Body = builder.ToMessageBody();

        return email;
    }

    private static void AddAttachmentsTo(BodyBuilder builder, IEnumerable<IFormFile> attachments)
    {
        if (attachments is null || !attachments.Any())
        {
            return;
        }

        byte[] fileBytes;

        foreach (var attachment in attachments)
        {
            if (attachment.Length <= 0)
            {
                continue;
            }

            using var stream = new MemoryStream();

            attachment.CopyTo(stream);

            fileBytes = stream.ToArray();

            var contentType = ContentType.Parse(attachment.ContentType);

            builder.Attachments.Add(attachment.FileName, fileBytes, contentType);
        }
    }
}
