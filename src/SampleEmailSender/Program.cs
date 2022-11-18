using SampleEmailSender.Emails;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var emailSection = builder.Configuration.GetSection(EmailOptions.Section);

builder.Services
    .Configure<EmailOptions>(emailSection)
    .AddScoped<IEmailService, EmailService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
