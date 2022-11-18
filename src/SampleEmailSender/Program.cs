using SampleEmailSender;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var emailSection = builder.Configuration.GetSection(EmailOptions.Section);

builder.Services.Configure<EmailOptions>(emailSection);

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
