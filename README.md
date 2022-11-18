# Sample Email Sender in ASP.NET Core

## Required NuGet Packages

CLI
```
dotnet add package MimeKit
dotnet add package MailKit
```

Package Manager Console
```
Install-Package MimeKit
Install-Package MailKit
```

## Gmail configurations

### To allow external apps to send emails, the following settings need to be configured in your Google Account:

* Go to: https://myaccount.google.com/apppasswords
* After you have authenticated, you need to generate a new application password
* Then copy and paste the generated password inside your ```appsettings.Development.json```

# WARNING
## Do not upload your ```appsettings.Development.json``` to source control as this will expose your sensitive gmail data

### Useful links
* https://code-maze.com/aspnetcore-send-email/
* https://mailtrap.io/blog/send-email-in-asp-net-c-sharp/
* https://www.youtube.com/watch?v=PvO_1T0FS_A&ab_channel=PatrickGod

