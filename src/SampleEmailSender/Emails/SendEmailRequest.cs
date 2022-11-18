namespace SampleEmailSender.Emails;

public sealed record SendEmailRequest(
    string EmailOfReceiver,
    string Subject,
    string Body,
    IEnumerable<IFormFile> Attachments);
