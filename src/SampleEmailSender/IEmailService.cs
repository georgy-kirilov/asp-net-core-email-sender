namespace SampleEmailSender;

public interface IEmailService
{
    Task SendEmail(SendEmailInputModel input);
}
