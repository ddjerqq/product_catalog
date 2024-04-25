using Application.Common.Abstractions;

namespace Infrastructure.Services;

public class GoogleEmailSender : IEmailSender
{
    public Task SendEmail(string address, string subject, string content)
    {
        throw new NotImplementedException();
    }
}