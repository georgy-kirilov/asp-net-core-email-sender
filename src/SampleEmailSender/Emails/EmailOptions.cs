namespace SampleEmailSender.Emails;

public sealed class EmailOptions
{
    public const string Section = "Email";

    required public string EmailOfSender { get; init; }

    required public string DisplayName { get; init; }

    required public string Password { get; init; }

    required public string Host { get; init; }

    required public int Port { get; init; }
}
