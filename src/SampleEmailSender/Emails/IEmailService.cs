namespace SampleEmailSender.Emails;

public interface IEmailService
{
    Task SendEmail(SendEmailRequest input);
}
