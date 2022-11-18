using Microsoft.AspNetCore.Mvc;

namespace SampleEmailSender.Emails;

[ApiController]
public sealed class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("email/send")]
    public async Task<IActionResult> Send([FromForm] SendEmailRequest input)
    {
        await _emailService.SendEmail(input);
        return Ok();
    }
}
