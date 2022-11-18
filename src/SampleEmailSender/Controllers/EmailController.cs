﻿using Microsoft.AspNetCore.Mvc;

using SampleEmailSender.Models;
using SampleEmailSender.Services;

namespace SampleEmailSender.Controllers;

[ApiController]
public sealed class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("email/send")]
    public async Task<IActionResult> Send([FromForm] SendEmailInputModel input)
    {
        await _emailService.SendEmail(input);
        return Ok();
    }
}
