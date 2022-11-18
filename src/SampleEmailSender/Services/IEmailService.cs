using SampleEmailSender.Models;

namespace SampleEmailSender.Services;

public interface IEmailService
{
    Task SendEmail(SendEmailInputModel input);
}
